using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mcknaldi.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public long EAN { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Aantal")]
        public int Amount { get; set; }
    }
}