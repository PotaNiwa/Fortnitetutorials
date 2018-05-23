using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Fortnitetutorials.Models;

namespace Fortnitetutorials.Controllers
{
    public class GuidesController : Controller
    {
        private MixupContext db = new MixupContext();

        // GET: Guides
        public ActionResult Index(string search)
        { 
            var guide = db.Guide.Include(g => g.Category);
            if (!string.IsNullOrEmpty(search))
            {
                guide = guide.Where(p => p.Title.Contains(search));
            }
            return View(guide.ToList());
        }

        // GET: Guides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guide guide = db.Guide.Find(id);
            if (guide == null)
            {
                return HttpNotFound();
            }
            return View(guide);
        }

        // GET: Guides/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Category, "ID", "Name");
            return View();
        }

        // POST: Guides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,ImageFile,CategoryID")] Guide guide, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                WebImage webImage = new WebImage(file.InputStream);
                webImage.Save("~/Content/Img" + file.FileName);
                guide.ImageFile = file.FileName;
                db.Guide.Add(guide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Category, "ID", "Name", guide.CategoryID);
            return View(guide);
        }

        // GET: Guides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guide guide = db.Guide.Find(id);
            if (guide == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Category, "ID", "Name", guide.CategoryID);
            return View(guide);
        }

        // POST: Guides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,ImageFile,CategoryID")] Guide guide)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Category, "ID", "Name", guide.CategoryID);
            return View(guide);
        }

        // GET: Guides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guide guide = db.Guide.Find(id);
            if (guide == null)
            {
                return HttpNotFound();
            }
            return View(guide);
        }

        // POST: Guides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guide guide = db.Guide.Find(id);
            db.Guide.Remove(guide);
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
