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
    public class SALECController : Controller
    {
        private example5_SBASAWAPPEntities db = new example5_SBASAWAPPEntities();

        // GET: SALEC
        public ActionResult Index()
        {
            return View(db.SALES.ToList());
        }

        // GET: SALEC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALE sALE = db.SALES.Find(id);
            if (sALE == null)
            {
                return HttpNotFound();
            }
            return View(sALE);
        }

        // GET: SALEC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SALEC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CLIENT_NAME,SALE_TOTAL")] SALE sALE)
        {
            if (ModelState.IsValid)
            {
                db.SALES.Add(sALE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sALE);
        }

        // GET: SALEC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALE sALE = db.SALES.Find(id);
            if (sALE == null)
            {
                return HttpNotFound();
            }
            return View(sALE);
        }

        // POST: SALEC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CLIENT_NAME,SALE_TOTAL")] SALE sALE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sALE);
        }

        // GET: SALEC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALE sALE = db.SALES.Find(id);
            if (sALE == null)
            {
                return HttpNotFound();
            }
            return View(sALE);
        }

        // POST: SALEC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SALE sALE = db.SALES.Find(id);
            db.SALES.Remove(sALE);
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
