
using DutchMilk.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchMilk.Data
{
    public class DutchContext:DbContext
    {
        public DutchContext(DbContextOptions<DutchContext> options):base (options)//options is for base constructor parameter
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
