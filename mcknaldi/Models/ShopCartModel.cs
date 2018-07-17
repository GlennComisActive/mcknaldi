using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mcknaldi.Models
{


    public class ShopCartModel
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

        public void Remove(int id)
        {
            items.RemoveAll(p => p.Product.Id == id);
        }

        public decimal Totalmoney()
        {
            decimal kq = 0;
            var total = items.Sum(p => p.Product.Price * p.Amount);
            if (total != null)kq = (decimal)total;
            return kq;
        }

        public void Clear()
        {
            items.Clear();
        }


    }
}