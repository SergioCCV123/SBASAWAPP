using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SBASAWAPP;

namespace SBASAWAPP.Controllers
{
    public class SHOPP_CARTController : Controller
    {
        private example5_SBASAWAPPEntities db = new example5_SBASAWAPPEntities();

        // GET: SHOPP_CART
        public ActionResult Index()
        {
            var sHOPP_CART = db.SHOPP_CART.Include(s => s.AspNetUsers).Include(s => s.PRODUCTS);
            return View(sHOPP_CART.ToList());
        }

        // GET: SHOPP_CART/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPP_CART sHOPP_CART = db.SHOPP_CART.Find(id);
            if (sHOPP_CART == null)
            {
                return HttpNotFound();
            }
            return View(sHOPP_CART);
        }

        // GET: SHOPP_CART/Create
        public ActionResult Create()
        {
            ViewBag.ID_USER = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ID_PRODUCT = new SelectList(db.PRODUCTS, "ID", "NAME");
            return View();
        }

        // POST: SHOPP_CART/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_USER,ID_PRODUCT,QUANTITY")] SHOPP_CART sHOPP_CART)
        {
            if (ModelState.IsValid)
            {
                db.SHOPP_CART.Add(sHOPP_CART);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_USER = new SelectList(db.AspNetUsers, "Id", "Email", sHOPP_CART.ID_USER);
            ViewBag.ID_PRODUCT = new SelectList(db.PRODUCTS, "ID", "NAME", sHOPP_CART.ID_PRODUCT);
            return View(sHOPP_CART);
        }

        // GET: SHOPP_CART/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPP_CART sHOPP_CART = db.SHOPP_CART.Find(id);
            if (sHOPP_CART == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_USER = new SelectList(db.AspNetUsers, "Id", "Email", sHOPP_CART.ID_USER);
            ViewBag.ID_PRODUCT = new SelectList(db.PRODUCTS, "ID", "NAME", sHOPP_CART.ID_PRODUCT);
            return View(sHOPP_CART);
        }

        // POST: SHOPP_CART/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USER,ID_PRODUCT,QUANTITY")] SHOPP_CART sHOPP_CART)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHOPP_CART).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_USER = new SelectList(db.AspNetUsers, "Id", "Email", sHOPP_CART.ID_USER);
            ViewBag.ID_PRODUCT = new SelectList(db.PRODUCTS, "ID", "NAME", sHOPP_CART.ID_PRODUCT);
            return View(sHOPP_CART);
        }

        // GET: SHOPP_CART/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPP_CART sHOPP_CART = db.SHOPP_CART.Find(id);
            if (sHOPP_CART == null)
            {
                return HttpNotFound();
            }
            return View(sHOPP_CART);
        }

        // POST: SHOPP_CART/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SHOPP_CART sHOPP_CART = db.SHOPP_CART.Find(id);
            db.SHOPP_CART.Remove(sHOPP_CART);
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
