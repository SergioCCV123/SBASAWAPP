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
    public class INSTALADORController : Controller
    {
        private example5_SBASAWAPPEntities db = new example5_SBASAWAPPEntities();

        // GET: INSTALADOR
        public ActionResult Index()
        {
            return View(db.INSTALADOR.ToList());
        }

        // GET: INSTALADOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSTALADOR iNSTALADOR = db.INSTALADOR.Find(id);
            if (iNSTALADOR == null)
            {
                return HttpNotFound();
            }
            return View(iNSTALADOR);
        }

        // GET: INSTALADOR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: INSTALADOR/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRol,Nombre,FechaRegistro")] INSTALADOR iNSTALADOR)
        {
            if (ModelState.IsValid)
            {
                db.INSTALADOR.Add(iNSTALADOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iNSTALADOR);
        }

        // GET: INSTALADOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSTALADOR iNSTALADOR = db.INSTALADOR.Find(id);
            if (iNSTALADOR == null)
            {
                return HttpNotFound();
            }
            return View(iNSTALADOR);
        }

        // POST: INSTALADOR/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRol,Nombre,FechaRegistro")] INSTALADOR iNSTALADOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNSTALADOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iNSTALADOR);
        }

        // GET: INSTALADOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSTALADOR iNSTALADOR = db.INSTALADOR.Find(id);
            if (iNSTALADOR == null)
            {
                return HttpNotFound();
            }
            return View(iNSTALADOR);
        }

        // POST: INSTALADOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INSTALADOR iNSTALADOR = db.INSTALADOR.Find(id);
            db.INSTALADOR.Remove(iNSTALADOR);
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
