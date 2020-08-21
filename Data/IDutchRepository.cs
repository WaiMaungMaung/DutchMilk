using DutchMilk.Data.Entities;
using System.Collections.Generic;

namespace DutchMilk.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductByCategory(string category);
        bool SaveAll();
    }
}