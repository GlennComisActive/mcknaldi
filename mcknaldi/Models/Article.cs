using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mcknaldi.Models
{
    public class Article
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Titel")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Beschrijving")]
        public string Description { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Afbeeldingspad")]
        public string ImagePath { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Geplaatst op")]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Gewijzigd op")]
        public DateTime UpdatedAt { get; set; }

        // Contructor
        public Article()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}