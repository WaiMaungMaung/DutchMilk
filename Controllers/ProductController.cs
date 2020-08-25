using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchMilk.Data;
using DutchMilk.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DutchMilk.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly IDutchRepository dutchRepository;
        private readonly ILogger<ProductController> logger;

        public ProductController(IDutchRepository dutchRepository,ILogger<ProductController> logger)
        {
            this.dutchRepository = dutchRepository;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try { 
            return Ok(dutchRepository.GetAllProducts());
            }
            catch(Exception e)
            {
                logger.LogError($"Fail to LOad {e}");
                return BadRequest("Fail to request product");
            }
        }
    }
}
