using DutchMilk.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
