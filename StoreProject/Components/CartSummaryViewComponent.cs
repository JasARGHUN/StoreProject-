using Microsoft.AspNetCore.Mvc;
using StoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProject.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartSevice)
        {
            cart = cartSevice;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
