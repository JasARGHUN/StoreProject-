using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreProject.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using StoreProject.Models.ViewModels;
using StoreProject.Infrastructure;
using System.Collections.Generic;

namespace StoreProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductRepository _repository;

        public AdminController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index() =>
            View(_repository.Products);

        public async Task<ViewResult> Edit(int productId)
        {
            return View(await _repository.Products
                .FirstOrDefaultAsync(p => p.ProductID == productId));
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if(image != null && image.Length > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\items", fileName);
                    using(var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileSteam);
                    }
                    product.Image = fileName;
                }
                //_repository.SaveProduct(product);
                _repository.Update(product);
                TempData["message"] = $"{product.Name} has been edit";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public async Task<IActionResult> Delete(int productId)
        {
            Product deleteProduct = await _repository.DeleteProduct(productId);

            if(deleteProduct != null)
            {
                TempData["message"] = $"{deleteProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
