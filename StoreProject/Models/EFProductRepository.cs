using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProject.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public EFProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public IQueryable<Product> Products => _context.Products;

        public async Task<Product> DeleteProduct(int productID)
        {
            Product dbEntry = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductID == productID);
            if(dbEntry != null)
            {
                _context.Products.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        public void SaveProduct(Product product)
        {
            if(product.ProductID == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                Product dbEntry = _context.Products
                    .FirstOrDefault(p => p.ProductID == product.ProductID);
                if(dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            _context.SaveChanges();
        }

        public Product Update(Product productDataUpdate)
        {
            var prod = _context.Products.Attach(productDataUpdate);
            prod.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return productDataUpdate;
        }
    }
}
