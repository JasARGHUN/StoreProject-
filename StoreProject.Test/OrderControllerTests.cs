using Microsoft.AspNetCore.Mvc;
using Moq;
using StoreProject.Controllers;
using StoreProject.Models;
using Xunit;

namespace StoreProject.Test
{
    public class OrderControllerTests
    {
        [Fact] //Проверка отсутствие возможности перехода к оплате при пустой корзине.
        public void Cannot_Checout_Empty_Cart()
        {
            //Организация.
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Cart cart = new Cart();
            Order order = new Order();
            OrderController target = new OrderController(mock.Object, cart);

            //Действие.
            ViewResult result = target.Checkout(order) as ViewResult;

            //Утверждение.
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);

            Assert.True(string.IsNullOrEmpty(result.ViewName));
            Assert.False(result.ViewData.ModelState.IsValid);
        }

        [Fact] //Проверка что пустая корзина или некорректные даные о доставке предотвращают сохранение заказов.
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {
            //Организация.
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            OrderController target = new OrderController(mock.Object, cart);
            target.ModelState.AddModelError("error", "error");

            //Действие.
            ViewResult result = target.Checkout(new Order()) as ViewResult;

            //Утверждение.
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
            Assert.True(string.IsNullOrEmpty(result.ViewName));
            Assert.False(result.ViewData.ModelState.IsValid);
        }

        [Fact] //Проверка что корректные заказы сохраняются в БД.
        public void Can_Checkout_And_Submit_Order()
        {
            //Организация.
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            OrderController target = new OrderController(mock.Object, cart);

            //Действие.
            RedirectToActionResult result = target.Checkout(new Order()) as RedirectToActionResult;

            //Утверждение.
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Once);
            Assert.Equal("Completed", result.ActionName);
        }

    }
}
