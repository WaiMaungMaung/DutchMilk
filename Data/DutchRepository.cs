using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchMilk.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace DutchMilk.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext ctx;
        private readonly ILogger<DutchRepository> logger;

        public DutchRepository(DutchContext ctx,ILogger<DutchRepository> logger)
        {
            this.ctx = ctx;
            this.logger = logger;
        }

        public void AddEntity(object model)
        {
            ctx.Add(model);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return ctx.Orders
                .Include(o=>o.Items)
                .ThenInclude(i=>i.Product)
                .ToList();
        }



        public IEnumerable<Product> GetAllProducts()
        {
            try { 
            logger.LogInformation("GetAllInformation");
            return ctx.Products.ToList();
            }
            catch (Exception e)
            {
                logger.LogError($"Fail to load:{e}");
                return null;
            }

        }

        public Order GetOrdersById(int id)
        {
            return ctx.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductByCategory(string category)
        {
            return ctx.Products.Where(p => p.Category == category).ToList();
        }

        public bool SaveAll()
        {
            return ctx.SaveChanges() > 0;
        }
    }
}
