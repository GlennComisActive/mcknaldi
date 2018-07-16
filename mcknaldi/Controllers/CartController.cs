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

        public ActionResult Delete(int id)
        {
            return View();
        }
        
    }
}