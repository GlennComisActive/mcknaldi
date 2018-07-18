using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mcknaldi.Models
{
    public class PromotionPageViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Promotion> Promotions { get; set; }
    }
}