using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mcknaldi.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Id { get; set; }
        public long EAN { get; set; }

        [Required]
        [Display(Name = "Aantal")]
        public int Amount { get; set; }
    }

    public class ShopCartModel
    {

            List<CartItem> items = new List<CartItem>();


            public IEnumerable<CartItem> Items
            {
                get { return items; }
            }

        public void Add(Product pr, int Amount = 1)
        {
            var item = items.Find(p => p.Product.Id == pr.Id);
            if (item == null)
            {
                items.Add(new CartItem { Product = pr, Amount = Amount });
            }
            else
            {
                item.Amount += Amount;
            }
        }


    }
}