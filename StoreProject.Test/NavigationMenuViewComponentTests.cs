using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using StoreProject.Components;
using StoreProject.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StoreProject.Test
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_select_Categories()
        {// Организация:
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                new Product {ProductID = 2, Name = "P2", Category = "Apples"},
                new Product {ProductID = 3, Name = "P3", Category = "Plums"},
                new Product {ProductID = 4, Name = "P4", Category = "Orange"},
            }).AsQueryable<Product>());

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);

            // Действие - получение набора категорий:
            string[] results = ((IEnumerable<string>)(target.Invoke() as ViewViewComponentResult).ViewData.Model).ToArray();

            // Утверждение:
            Assert.True(Enumerable.SequenceEqual(new string[]
            {
                "Apples", "Orange", "Plums"
            }, results));
        }
    }
}
