using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreProject.Models;
using StoreProject.Models.ViewModels;
using System.Linq;
using StoreProject.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace StoreProject.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _repository;
        private Cart cart;

        public CartController(IProductRepository repository, Cart cartService)
        {
            _repository = repository;
            cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public async Task<RedirectToActionResult> AddToCart(int productId, string returnUrl)
        {
            Product product = await _repository.Products
                .FirstOrDefaultAsync(p => p.ProductID == productId);
            if(product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl});
        }

        public async Task<RedirectToActionResult> RemoveFromCart(int productId, string returnUrl)
        {
            Product product = await _repository.Products
                .FirstOrDefaultAsync(p => p.ProductID == productId);

            if(product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
