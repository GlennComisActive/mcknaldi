using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mcknaldi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Bestellings code")]
        public string OrderCode { get; set; }

        [Required]
        [Display(Name = "Bestellings Naam")]
        public string OrderName { get; set; }

        [Required]
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Totaal prijs")]
        public decimal TotalPrice { get; set; }

        public Status Status { get; set; }
    }
    public enum Status
    {
        In_behandeling,
        Afgekeurd,
        afgerond
    }
}