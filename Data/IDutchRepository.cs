using DutchMilk.Data.Entities;
using System.Collections.Generic;

namespace DutchMilk.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductByCategory(string category);
        
        IEnumerable<Order> GetAllOrders();
        Order GetOrdersById(int id);

        bool SaveAll();
        void AddEntity(object model);
    }
}