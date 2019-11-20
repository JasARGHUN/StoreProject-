using StoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace StoreProject.Test
{
    public class CartTests
    {
        [Fact]
        public void Can_Add_New_Lines()
        {
            //Организация.
            Product p1 = new Product { ProductID = 1, Name = "Object 1" };
            Product p2 = new Product { ProductID = 2, Name = "Object 2" };
            Cart target = new Cart();

            //Действие.
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            CartLine[] result = target.Lines.ToArray();

            //Утверждение.
            Assert.Equal(2, result.Length);
            Assert.Equal(p1, result[0].Product);
            Assert.Equal(p2, result[1].Product);
        }

        [Fact]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            //Организация.
            Product p1 = new Product { ProductID = 1, Name = "Object 1" };
            Product p2 = new Product { ProductID = 2, Name = "Object 2" };
            Cart target = new Cart();

            //Действие.
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);
            CartLine[] results = target.Lines
                .OrderBy(c => c.Product.ProductID).ToArray();

            //Утверждение.
            Assert.Equal(2, results.Length);
            Assert.Equal(11, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);
        }

        [Fact]
        public void Can_Remove_Line()
        {
            //Организация.
            Product p1 = new Product { ProductID = 1, Name = "Object 1" };
            Product p2 = new Product { ProductID = 2, Name = "Object 2" };
            Product p3 = new Product { ProductID = 3, Name = "Object 3" };

            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);

            //Действие.
            target.RemoveLine(p2);

            //Утверждение.
            Assert.Empty(target.Lines.Where(c => c.Product == p2));
            Assert.Equal(2, target.Lines.Count());
        }

        [Fact]
        public void Calculate_Cart_Total()
        {
            //Организация.
            Product p1 = new Product { ProductID = 1, Name = "Object 1", Price = 150 };
            Product p2 = new Product { ProductID = 2, Name = "Object 2", Price = 55 };

            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            decimal result = target.ComputeTotalValue();

            //Действие.
            Assert.Equal(205, result);
        }

        [Fact]
        public void Can_Clear_Contents()
        {
            //Организация.
            Product p1 = new Product { ProductID = 1, Name = "Object-1", Price = 50M };
            Product p2 = new Product { ProductID = 2, Name = "Object-2", Price = 25M };

            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 1);

            //Действие.
            target.Clear();

            //Утверждение.
            Assert.Empty(target.Lines);
        }
    }
}
