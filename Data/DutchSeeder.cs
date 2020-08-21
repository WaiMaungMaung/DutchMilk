using DutchMilk.Data.Entities;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DutchMilk.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext ctx;
        private readonly IHostEnvironment hostingEnvironment;

        public DutchSeeder(DutchContext ctx,IHostEnvironment hostingEnvironment)
        {
            this.ctx = ctx;
            this.hostingEnvironment = hostingEnvironment;
        }
        public void Seed()
        {
            ctx.Database.EnsureCreated();
            if (!ctx.Products.Any())
            {

                var filepath = Path.Combine(hostingEnvironment.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                ctx.Products.AddRange(products);

                var order = ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product=products.First(),
                    Quantity = 5,
                    UnitPrice=products.First().Price

                        }
                    };
                }

                ctx.SaveChanges();  
            }
        }
    }
}
