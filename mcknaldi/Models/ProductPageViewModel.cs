using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mcknaldi.Models
{
    public class ProductPageViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}