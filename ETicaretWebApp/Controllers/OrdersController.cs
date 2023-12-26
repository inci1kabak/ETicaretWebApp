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
using Microsoft.AspNet.Identity;

namespace ETicaretWebApp.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private string userId=string.Empty;
        public OrdersController()
        {
        }
        // GET: Orders
        public ActionResult Index()
        {
            userId = HttpContext.User.Identity.GetUserId();

            return View(db.Orders.Where(p=>p.OrderedById==userId).ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null||order.OrderedById!= HttpContext.User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            var list=db.Products.ToList();
            ViewBag.ProductList = new SelectList(db.Products.ToList().AsEnumerable(), "Id", "ProductName");
            return View();
        }

        // POST: Orders/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address,Phone,Email")] Order order, int[] ProductIds)
        {
            userId = HttpContext.User.Identity.GetUserId();
            order.OrderedById = userId;
            order.CreatedById = userId;
            order.UpdatedDate = DateTime.Now;

            db.Orders.Add(order);
            db.SaveChanges();
            foreach (var productId in ProductIds)
            {
                var orderProduct = new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = productId
                };
                db.OrderProducts.Add(orderProduct);

                
            }
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
