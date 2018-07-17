using mcknaldi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mcknaldi.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Add(int id)
        {
            ShopCartModel cart = Session["Cart"] as ShopCartModel;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new ShopCartModel();
                Session["Cart"] = cart;

            }
            var itemproduct = db.Products.Where(p => p.Id == id).First();
            cart.Add(itemproduct);
            return RedirectToAction("Details", "Products", new {id = id});
        }

        public ActionResult ShopCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("Index", "Categories");
            ShopCartModel cart = Session["Cart"] as ShopCartModel;
            return View(cart);
        }

        public ActionResult Update(FormCollection form)
        {
            ShopCartModel cart = Session["Cart"] as ShopCartModel;
            int idpr = Int32.Parse(form["ProductId"]);
            int sl = Int32.Parse(form["Amount"]);
            cart.Update(idpr, sl);
            return RedirectToAction("ShopCart", "Cart");
        }

        public ActionResult Delete(int id)
        {
            ShopCartModel cart = Session["Cart"] as ShopCartModel;
            cart.Delete(id);
            return RedirectToAction("ShopCart", "Cart");
        }

        public PartialViewResult Shop()
        {
            decimal totalitem = 0;
            ShopCartModel cart = Session["Cart"] as ShopCartModel;
            if (cart != null)
                totalitem = cart.CartTotal();
            ViewBag.infoCart = totalitem;
            return PartialView("Shop");
        }

        public ActionResult Checkout()
        {
            ShopCartModel cart = Session["Cart"] as ShopCartModel;

            //save order
            Order order = new Order();
            order.OrderName = "Referentie";
            order.OrderCode = "Bestelling-" + DateTime.Now.ToString("dd-MM-yyyy hh:mm");
            order.Date = DateTime.Now;
            order.TotalPrice = cart.CartTotal();
            db.Orders.Add(order);

            int OrderId = order.Id;

            foreach (var item in cart.Items)
            {
                decimal CartTotal = item.Amount * item.Product.Price;
                OrderLijst orderlijst = new OrderLijst();
                orderlijst.OrderCode = order.OrderCode;
                orderlijst.Product = item.Product;
                orderlijst.ProductName = item.Product.Title;
                orderlijst.Amount = item.Amount;
                orderlijst.Price = item.Product.Price;
                orderlijst.TotalPrice = CartTotal;
                db.OrderLijsts.Add(orderlijst);
            }
            db.SaveChanges();

            cart.Clear();

            return RedirectToAction("ShopCart", "Cart");
        }
    }
}