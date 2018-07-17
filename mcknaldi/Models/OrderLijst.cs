using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mcknaldi.Models
{
    public class OrderLijst
    {
        public int id { get; set; }

        public string OrderCode { get; set; }

        [Display(Name = "Hoeveelheid")]
        public int Amount { get; set; }

        public Product Product { get; set; }

        [Display(Name = "ProductNaam")]
        public string ProductName { get; set; }

        [Display(Name = "Prijs")]
        public decimal Price { get; set; }

        [Display(Name = "Totaalprijs")]
        public decimal TotalPrice { get; set; }
    }
}