using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProject.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        Product GetProduct(int id);
        void SaveProduct(Product product);
        Product Update(Product productDataUpdate);
        Task<Product> DeleteProduct(int productID);
    }
}
