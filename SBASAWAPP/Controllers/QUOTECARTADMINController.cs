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
    public class QUOTECARTADMINController : Controller
    {
        private example5_SBASAWAPPEntities db = new example5_SBASAWAPPEntities();

        // GET: QUOTECARTADMIN
        public ActionResult Index()
        {
            var qUOTECARTs = db.QUOTECARTs.Include(q => q.AspNetUser).Include(q => q.PRODUCT);
            qUOTECARTs.OrderBy(m => m.FECHA);
            return View(qUOTECARTs.ToList());
        }

        // GET: QUOTECARTADMIN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUOTECART qUOTECART = db.QUOTECARTs.Find(id);
            if (qUOTECART == null)
            {
                return HttpNotFound();
            }
            return View(qUOTECART);
        }

        // GET: QUOTECARTADMIN/Create
        public ActionResult Create()
        {
            ViewBag.ID_USER = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ID_PRODUCT = new SelectList(db.PRODUCTS, "ID", "NAME");
            return View();
        }

        // POST: QUOTECARTADMIN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_USER,ID_PRODUCT,QUANTITY,RESULTADO,ACTIVO")] QUOTECART qUOTECART)
        {
            if (ModelState.IsValid)
            {
                db.QUOTECARTs.Add(qUOTECART);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_USER = new SelectList(db.AspNetUsers, "Id", "Email", qUOTECART.ID_USER);
            ViewBag.ID_PRODUCT = new SelectList(db.PRODUCTS, "ID", "NAME", qUOTECART.ID_PRODUCT);
            return View(qUOTECART);
        }

        // GET: QUOTECARTADMIN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUOTECART qUOTECART = db.QUOTECARTs.Find(id);
            if (qUOTECART == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_USER = new SelectList(db.AspNetUsers, "Id", "Email", qUOTECART.ID_USER);
            ViewBag.ID_PRODUCT = new SelectList(db.PRODUCTS, "ID", "NAME", qUOTECART.ID_PRODUCT);
            return View(qUOTECART);
        }

        // POST: QUOTECARTADMIN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_USER,ID_PRODUCT,QUANTITY,RESULTADO,ACTIVO, FECHA")] QUOTECART qUOTECART)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUOTECART).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_USER = new SelectList(db.AspNetUsers, "Id", "Email", qUOTECART.ID_USER);
            ViewBag.ID_PRODUCT = new SelectList(db.PRODUCTS, "ID", "NAME", qUOTECART.ID_PRODUCT);
            return View(qUOTECART);
        }

        // GET: QUOTECARTADMIN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUOTECART qUOTECART = db.QUOTECARTs.Find(id);
            if (qUOTECART == null)
            {
                return HttpNotFound();
            }
            return View(qUOTECART);
        }

        // POST: QUOTECARTADMIN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QUOTECART qUOTECART = db.QUOTECARTs.Find(id);
            db.QUOTECARTs.Remove(qUOTECART);
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
