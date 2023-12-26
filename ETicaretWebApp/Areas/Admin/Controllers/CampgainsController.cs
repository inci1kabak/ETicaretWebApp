using ETicaretWebApp.Models.Entities;
using ETicaretWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ETicaretWebApp.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize(Roles = "Admin")]
    public class CampgainsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Campgain
        public ActionResult Index()
        {
            var campgains = db.Campgains.Include(c => c.CreatedBy);
            return View(campgains.ToList());
        }

        // GET: Admin/Campgain/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campgain campgain = db.Campgains.Find(id);
            if (campgain == null)
            {
                return HttpNotFound();
            }
            return View(campgain);
        }

        // GET: Admin/Campgain/Create
        public ActionResult Create()
        {
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Admin/Campgain/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CampgainName,StartDate,EndDate,CreatedDate,UpdatedDate,CreatedById")] Campgain campgain)
        {
            if (ModelState.IsValid)
            {
                db.Campgains.Add(campgain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Email", campgain.CreatedById);
            return View(campgain);
        }

        // GET: Admin/Campgain/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campgain campgain = db.Campgains.Find(id);
            if (campgain == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Email", campgain.CreatedById);
            return View(campgain);
        }

        // POST: Admin/Campgain/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CampgainName,StartDate,EndDate,CreatedDate,UpdatedDate,CreatedById")] Campgain campgain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campgain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Email", campgain.CreatedById);
            return View(campgain);
        }

        // GET: Admin/Campgain/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campgain campgain = db.Campgains.Find(id);
            if (campgain == null)
            {
                return HttpNotFound();
            }
            return View(campgain);
        }

        // POST: Admin/Campgain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campgain campgain = db.Campgains.Find(id);
            db.Campgains.Remove(campgain);
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