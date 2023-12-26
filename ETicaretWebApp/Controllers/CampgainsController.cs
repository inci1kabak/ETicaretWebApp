using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETicaretWebApp.Models;
using ETicaretWebApp.Models.Entities;

namespace ETicaretWebApp.Controllers
{
    public class CampgainsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Campgains
        public ActionResult Index()
        {
            return View(db.Campgains.ToList());
        }

        // GET: Campgains/Details/5
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
