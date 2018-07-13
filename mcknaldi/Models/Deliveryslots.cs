using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mcknaldi.Models
{
    public class Deliveryslots
    {
        public int Id { get; set; }

        [Display(Name = "Datum")]
        public DateTime DateSlot { get; set; }

        [Display(Name = "Begintijd")]
        public string StartTime { get; set; }

        [Display(Name = "Eindtijd")]
        public string EndTime { get; set; }

        [Display(Name = "Prijs")]
        public decimal Price { get; set; }
    }
}