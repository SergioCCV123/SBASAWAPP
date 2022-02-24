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
    public class SALESController : Controller
    {
        private example5_SBASAWAPPEntities db = new example5_SBASAWAPPEntities();

        // GET: SALES
        public ActionResult Index()
        {
            return View(db.SALES.ToList());
        }

        // GET: SALES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALES sALES = db.SALES.Find(id);
            if (sALES == null)
            {
                return HttpNotFound();
            }
            return View(sALES);
        }

        // GET: SALES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SALES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CLIENT_NAME,SALE_TOTAL")] SALES sALES)
        {
            if (ModelState.IsValid)
            {
                db.SALES.Add(sALES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sALES);
        }

        // GET: SALES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALES sALES = db.SALES.Find(id);
            if (sALES == null)
            {
                return HttpNotFound();
            }
            return View(sALES);
        }

        // POST: SALES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CLIENT_NAME,SALE_TOTAL")] SALES sALES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sALES);
        }

        // GET: SALES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALES sALES = db.SALES.Find(id);
            if (sALES == null)
            {
                return HttpNotFound();
            }
            return View(sALES);
        }

        // POST: SALES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SALES sALES = db.SALES.Find(id);
            db.SALES.Remove(sALES);
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
