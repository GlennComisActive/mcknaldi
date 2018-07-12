using mcknaldi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mcknaldi.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Dashboard
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var countArticles = db.Articles
            .Count();
            ViewBag.countArticles = countArticles;

            var countProducts = db.Products
            .Count();
            ViewBag.countProducts = countProducts;

            var countPromotions = db.Promotions
            .Count();
            ViewBag.countPromotions = countPromotions;

            return View();
        }
    }
}