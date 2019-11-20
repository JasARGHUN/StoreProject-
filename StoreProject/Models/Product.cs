using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProject.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage= "Name field can't be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description field can't be empty")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price field can't be empty")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category field can't be empty")]
        public string Category { get; set; }

        public string Image { get; set; }
    }
}
