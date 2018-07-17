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

        public void Delete(int id)
        {
            items.RemoveAll(p => p.Product.Id == id);
        }

        public void Update(int id , int amount)
        {
            var item = items.Find(p => p.Product.Id == id);
            if (item != null)
                item.Amount = amount;
        }

        public int CartTotal()
        {
            int Totaal = 0;
            var total = items.Sum(p => p.Product.Price * p.Amount);
            if (total != null) Totaal = (int)total;
            return Totaal;
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}