using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mcknaldi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Security;
using Newtonsoft.Json;
using System.Collections;
using System.IO;

namespace mcknaldi.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Articles
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Articles.ToList());

            
        }

        // GET: Admin/Articles/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Admin/Articles/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Content,ImagePath,ImageUpload")] Article article, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();

                if (ImageUpload != null && ImageUpload.ContentLength > 0)
                {
                    // directory aanmaken
                    var uploadPath = Path.Combine(Server.MapPath("~/Uploads/Content"), article.Id.ToString());
                    Directory.CreateDirectory(uploadPath);
                    // TODO: oude afbeelding verwijderen
                    // bestandsnaam maken, op basis van een random string (GUID)
                    string fileGuid = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(ImageUpload.FileName);
                    string newFilename = fileGuid + extension;
                    // bestand opslaan
                    ImageUpload.SaveAs(Path.Combine(uploadPath, newFilename));
                    // opslaan in database
                    article.ImagePath = newFilename;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(article);
        }



        // GET: Admin/Articles/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Content,ImagePath,ImageUpload,CreatedAt")] Article article, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                article.UpdatedAt = DateTime.Now;
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                if (ImageUpload != null && ImageUpload.ContentLength > 0)
                {
                    // directory aanmaken
                    var uploadPath = Path.Combine(Server.MapPath("~/Uploads/Content"), article.Id.ToString());
                    Directory.CreateDirectory(uploadPath);
                    // TODO: oude afbeelding verwijderen
                    // bestandsnaam maken, op basis van een random string (GUID)
                    string fileGuid = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(ImageUpload.FileName);
                    string newFilename = fileGuid + extension;
                    // bestand opslaan
                    ImageUpload.SaveAs(Path.Combine(uploadPath, newFilename));
                    // opslaan in database
                    article.ImagePath = newFilename;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Admin/Articles/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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
