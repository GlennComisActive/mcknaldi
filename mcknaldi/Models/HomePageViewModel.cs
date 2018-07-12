using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mcknaldi.Models
{
    public class HomePageViewModel
    {
       public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Promotion> Promotions { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}