using Microsoft.AspNetCore.Mvc;
using Moq;
using StoreProject.Controllers;
using StoreProject.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace StoreProject.Test
{
    public class AdminControllerTests
    {
        //[Fact]
        //public void Index_Contains_All_Products() //тестируем метод Index() контроллера Admin, который должен корректные объекты Product из БД.
        //{
        //    //Организация.
        //    Mock<IProductRepository> mock = new Mock<IProductRepository>();
        //    mock.Setup(m => m.Products).Returns((new Product[]
        //    {
        //        new Product { ProductID = 1, Name = "Object 1"},
        //        new Product { ProductID = 2, Name = "Object 2"},
        //        new Product { ProductID = 3, Name = "Object 3"}
        //    }).AsQueryable<Product>());
        //    AdminController target = new AdminController(mock.Object);

        //    //Действие.
        //    Product[] result = GetViewModel<IEnumerable<Product>>(target.Index())?.ToArray();

        //    //Утверждение.
        //    Assert.Equal(3, result.Length);
        //    Assert.Equal("Object 1", result[0].Name);
        //    Assert.Equal("Object 2", result[1].Name);
        //    Assert.Equal("Object 3", result[2].Name);
        //}

        //[Fact]
        //public void Can_Edit_Product()
        //{
        //    //Организация.
        //    Mock<IProductRepository> mock = new Mock<IProductRepository>();
        //    mock.Setup(m => m.Products).Returns((new Product[]
        //    {
        //        new Product {ProductID = 1, Name = "Object 1"},
        //        new Product {ProductID = 2, Name = "Object 2"},
        //        new Product {ProductID = 3, Name = "Object 3"}
        //    }).AsQueryable<Product>());
        //    AdminController target = new AdminController(mock.Object);

        //    //Действие.
        //    Product p1 = GetViewModel<Product>(target.Edit(1));
        //    Product p2 = GetViewModel<Product>(target.Edit(2));
        //    Product p3 = GetViewModel<Product>(target.Edit(3));

        //    //Утверждение.
        //    Assert.Equal(1, p1.ProductID);
        //    Assert.Equal(2, p2.ProductID);
        //    Assert.Equal(3, p3.ProductID);
        //}

        //[Fact]
        //public void Cannot_Edit_Nonexistent_Product()
        //{
        //    //Организация.
        //    Mock<IProductRepository> mock = new Mock<IProductRepository>();
        //    mock.Setup(m => m.Products).Returns((new Product[]
        //    {
        //        new Product {ProductID = 1, Name = "Object 1"},
        //        new Product {ProductID = 2, Name = "Object 2"},
        //        new Product {ProductID = 3, Name = "Object 3"}
        //    }).AsQueryable<Product>());
        //    AdminController target = new AdminController(mock.Object);

        //    //Действие.
        //    Product result = GetViewModel<Product>(target.Edit(4));

        //    //Утверждение.
        //    Assert.Null(result);
        //}

//        [Fact]
//        public void Can_Save_Valid_Changes()
//        {
//            //Организация.
//            Mock<IProductRepository> mock = new Mock<IProductRepository>();
//            Mock<ITempDataDictionary> tempData = new Mock<ITempDataDictionary>();
//            AdminController target = new AdminController(mock.Object)
//            {
//                TempData = tempData.Object
//            };
//            Product product = new Product { Name = "Some Object" };

//            //Действие.
//            IActionResult result = target.Edit(product);

//            //Утверждение.
//            mock.Verify(m => m.SaveProduct(product));
//            Assert.IsType<RedirectToActionResult>(result);
//            Assert.Equal("Index", (result as RedirectToActionResult).ActionName);
//        }

//        [Fact]
//        public void Cannot_Save_Invalid_Changes()
//        {
//            //Организация.
//            Mock<IProductRepository> mock = new Mock<IProductRepository>();
//            AdminController target = new AdminController(mock.Object);
//            Product product = new Product { Name = "Object 1" };
//            target.ModelState.AddModelError("error", "error");

//            //Действие.
//            IActionResult result = target.Edit(product);

//            //Утверждение.
//            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());
//            Assert.IsType<ViewResult>(result);
//        }

//        [Fact]
//        public async void Can_Delete_Valid_Object()
//        {
//            //Организация.
//            Product product = new Product { ProductID = 2, Name = "Object 1" };
//            Mock<IProductRepository> mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.Products).Returns((new Product[]
//            {
//                new Product {ProductID = 1, Name = "Object 2" },
//                new Product {ProductID = 3, Name = "Object 3"}
//            }).AsQueryable<Product>());

//            AdminController target = new AdminController(mock.Object);

//            //Действие.
//            await target.Delete(product.ProductID);

//            //Утверждение.
//            mock.Verify(m => m.DeleteProduct(product.ProductID));
//        }
    }
}
