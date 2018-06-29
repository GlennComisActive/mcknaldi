using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mcknaldi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int ApiId { get; set; }
        public long EAN { get; set; }

        [Required]
        [Display(Name = "Product")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Merk")]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Kleine beschrijving")]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Grootte beschrijving")]
        public string FullDescription { get; set; }

        [Required]
        [Display(Name = "Afbeelding")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "Gewicht")]
        public string Weight { get; set; }

        [Required]
        [Display(Name = "Prijs")]
        public decimal Price { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}