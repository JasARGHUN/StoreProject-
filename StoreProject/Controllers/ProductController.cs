using Microsoft.AspNetCore.Mvc;
using StoreProject.Models;
using StoreProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StoreProject.Infrastructure;

namespace StoreProject.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List(string category, int productPage = 1) =>
            View(new ProductsListViewModel
            {
                Products = _repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    _repository.Products.Count() :
                    _repository.Products.Where(e =>
                    e.Category == category).Count()
                },
                CurrentCategory = category
            });

        public ViewResult Details(int id)
        {
            Product product = _repository.GetProduct(id);
            return View(product);
        }
    }
}
