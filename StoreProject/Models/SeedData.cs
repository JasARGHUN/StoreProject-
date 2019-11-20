using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProject.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            //ApplicationDBContext context = app.ApplicationServices.GetRequiredService<ApplicationDBContext>();
            //context.Database.Migrate();
            //if (!context.Products.Any())
            //{
            //    context.Products.AddRange(
            //        new Product
            //        {
            //            Name = "Product 1",
            //            Description = "Some product descriptons ...",
            //            Category = "Category 1",
            //            Price = 5000
            //        },
            //        new Product
            //        {
            //            Name = "Product 2",
            //            Description = "Some product descriptons ...",
            //            Category = "Category 1",
            //            Price = 5000
            //        },
            //        new Product
            //        {
            //            Name = "Product 3",
            //            Description = "Some product descriptons ...",
            //            Category = "Category 1",
            //            Price = 5000
            //        },
            //        new Product
            //        {
            //            Name = "Product 4",
            //            Description = "Some product descriptons ...",
            //            Category = "Category 1",
            //            Price = 5000
            //        },
            //        new Product
            //        {
            //            Name = "Product 5",
            //            Description = "Some product descriptons ...",
            //            Category = "Category 2",
            //            Price = 5000
            //        },
            //        new Product
            //        {
            //            Name = "Product 6",
            //            Description = "Some product descriptons ...",
            //            Category = "Category 2",
            //            Price = 5000
            //        },
            //        new Product
            //        {
            //            Name = "Product 7",
            //            Description = "Some product descriptons ...",
            //            Category = "Category 2",
            //            Price = 5000
            //        },
            //        new Product
            //        {
            //            Name = "Product 8",
            //            Description = "Some product descriptons ...",
            //            Category = "Category 2",
            //            Price = 5000
            //        },
            //        new Product
            //        {
            //            Name = "Product 9",
            //            Description = "Some product descriptons ...",
            //            Category = "Category 3",
            //            Price = 5000
            //        },
            //        new Product
            //        {
            //            Name = "Product 10",
            //            Description = "Some product descriptons ...",
            //            Category = "Category 3",
            //            Price = 5000
            //        },
            //        new Product
            //        {
            //            Name = "Product 11",
            //            Description = "Some product descriptons ...",
            //            Category = "Category 3",
            //            Price = 5000
            //        },
            //        new Product
            //        {
            //            Name = "Product 12",
            //            Description = "Some product descriptons ...",
            //            Category = "Category 3",
            //            Price = 5000
            //        }
            //    );
            //    context.SaveChanges();
            //}
        }
    }
}
