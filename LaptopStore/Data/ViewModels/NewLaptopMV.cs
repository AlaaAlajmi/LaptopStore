using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LaptopStore.Data.Base;

namespace LaptopStore.Models
{
    public class NewLaptopMV
    {
        public int Id { get; set; }
        [Display(Name = "Laptop Name")]
        [Required(ErrorMessage = "Name is required")]
        public string ProductName { get; set; }

        [Display(Name = "Laptop Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in Kd")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Laptop Image URL")]
        [Required(ErrorMessage = "Laptop Image URL is required")]
        public string ImageUrl { get; set; }


    }
}
