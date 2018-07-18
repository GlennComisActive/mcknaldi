using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mcknaldi.Models
{
    public class OrderPageViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderLijst> OrderLijsts { get; set; }
    }
}