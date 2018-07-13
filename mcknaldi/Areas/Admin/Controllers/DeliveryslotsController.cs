using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mcknaldi.Models;

namespace mcknaldi.Areas.Admin.Controllers
{
    public class DeliveryslotsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Deliveryslots
        public ActionResult Index()
        {
            return View(db.Deliveryslots.ToList());
        }

        // GET: Admin/Deliveryslots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliveryslots deliveryslots = db.Deliveryslots.Find(id);
            if (deliveryslots == null)
            {
                return HttpNotFound();
            }
            return View(deliveryslots);
        }

        // GET: Admin/Deliveryslots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Deliveryslots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateSlot,StartTime,EndTime,Price")] Deliveryslots deliveryslots)
        {
            if (ModelState.IsValid)
            {
                db.Deliveryslots.Add(deliveryslots);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryslots);
        }

        // GET: Admin/Deliveryslots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliveryslots deliveryslots = db.Deliveryslots.Find(id);
            if (deliveryslots == null)
            {
                return HttpNotFound();
            }
            return View(deliveryslots);
        }

        // POST: Admin/Deliveryslots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateSlot,StartTime,EndTime,Price")] Deliveryslots deliveryslots)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryslots).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryslots);
        }

        // GET: Admin/Deliveryslots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliveryslots deliveryslots = db.Deliveryslots.Find(id);
            if (deliveryslots == null)
            {
                return HttpNotFound();
            }
            return View(deliveryslots);
        }

        // POST: Admin/Deliveryslots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deliveryslots deliveryslots = db.Deliveryslots.Find(id);
            db.Deliveryslots.Remove(deliveryslots);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
