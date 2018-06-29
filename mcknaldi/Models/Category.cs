using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mcknaldi.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Categorie")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Categorie type")]
        public string Type { get; set; }

        [Display(Name = "Afbeelding")]
        public string Image { get; set; }

        public int? ParentId { get; set; }
        public  virtual Category Parent { get; set; }
    }
}