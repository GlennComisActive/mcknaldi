using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mcknaldi.Models
{
    public class Promotion
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Titel")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Korting")]
        [DataType(DataType.Currency)]
        public decimal DiscountPrice { get; set; }

        [Required]
        [Display(Name = "Verkrijgbaar tot")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ValidUntil { get; set; }

        [Required]
        [Display(Name = "EAN")]
        public long ProductEAN { get; set; }
        public virtual Product Product { get; set; }
    }
}