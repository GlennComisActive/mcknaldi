using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mcknaldi.Models
{
    public class Deliveryslots
    {
        public int Id { get; set; }
        public DateTime DateSlot { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public decimal Price { get; set; }
    }
}