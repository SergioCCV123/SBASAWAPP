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
    public class NOTIFICATIONController : Controller
    {
        private example5_SBASAWAPPEntities db = new example5_SBASAWAPPEntities();

        // GET: NOTIFICATION
        public ActionResult Index()
        {
            var nOTIFICATIONS = db.NOTIFICATIONS.Include(n => n.AspNetUser);
            return View(nOTIFICATIONS.ToList());
        }

        // GET: NOTIFICATION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTIFICATION nOTIFICATION = db.NOTIFICATIONS.Find(id);
            if (nOTIFICATION == null)
            {
                return HttpNotFound();
            }
            return View(nOTIFICATION);
        }

        // GET: NOTIFICATION/Create
        public ActionResult Create()
        {
            ViewBag.IDUSER = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: NOTIFICATION/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDUSER,MESSAGE,ACTIVO,FECHA")] NOTIFICATION nOTIFICATION)
        {
            if (ModelState.IsValid)
            {
                db.NOTIFICATIONS.Add(nOTIFICATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDUSER = new SelectList(db.AspNetUsers, "Id", "Email", nOTIFICATION.IDUSER);
            return View(nOTIFICATION);
        }

        // GET: NOTIFICATION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTIFICATION nOTIFICATION = db.NOTIFICATIONS.Find(id);
            if (nOTIFICATION == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDUSER = new SelectList(db.AspNetUsers, "Id", "Email", nOTIFICATION.IDUSER);
            return View(nOTIFICATION);
        }

        // POST: NOTIFICATION/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDUSER,MESSAGE,ACTIVO,FECHA")] NOTIFICATION nOTIFICATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOTIFICATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDUSER = new SelectList(db.AspNetUsers, "Id", "Email", nOTIFICATION.IDUSER);
            return View(nOTIFICATION);
        }

        // GET: NOTIFICATION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTIFICATION nOTIFICATION = db.NOTIFICATIONS.Find(id);
            if (nOTIFICATION == null)
            {
                return HttpNotFound();
            }
            return View(nOTIFICATION);
        }

        // POST: NOTIFICATION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NOTIFICATION nOTIFICATION = db.NOTIFICATIONS.Find(id);
            db.NOTIFICATIONS.Remove(nOTIFICATION);
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
