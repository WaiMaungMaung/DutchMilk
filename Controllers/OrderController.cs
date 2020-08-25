using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DutchMilk.Data;
using DutchMilk.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DutchMilk.Controllers
{
    [Route("api/[Controller]")]
    public class OrderController : Controller

    {
        private readonly IDutchRepository dutchRepository;
        private readonly ILogger<OrderController> logger;
        private readonly IMapper mapper;

        public OrderController(IDutchRepository dutchRepository, ILogger<OrderController> logger, IMapper mapper)
        {
            this.dutchRepository = dutchRepository;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(dutchRepository.GetAllOrders());


            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get orders: {ex}");
                return BadRequest("Failed to get orders");
            }
        }


        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var value = dutchRepository.GetOrdersById(id);
                if (value != null) { return Ok(value); }
                
                else
                {
                   return NotFound();
                }


            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get orders: {ex}");
                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody]Order model)
        {
            try
            {

                dutchRepository.AddEntity(model);
                if(dutchRepository.SaveAll())
                return Created($"api/order/{model.Id}", model);
                    //Ok(model);
            }
            catch(Exception e)
            {
                logger.LogError($"Failed to save a new order{e}");
                
            }
            return BadRequest("Posting Error");
        }

    }
}
