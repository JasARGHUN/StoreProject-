﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreProject.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace StoreProject.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _repository;
        private Cart _cart;

        public OrderController(IOrderRepository repositoryService, Cart cartService)
        {
            _repository = repositoryService;
            _cart = cartService;
        }

        [Authorize]
        public ViewResult List() =>
            View(_repository.Orders.Where(o => !o.Shipped));

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MarkShipped(int orderID)
        {
            Order order = await _repository.Orders
                .FirstOrDefaultAsync(o => o.OrderID == orderID);
            if(order != null)
            {
                order.Shipped = true;
                _repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout() =>
            View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }
            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            _cart.Clear();
            return View();
        }
    }
}
