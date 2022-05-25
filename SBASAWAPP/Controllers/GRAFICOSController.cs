using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SBASAWAPP;
using SBASAWAPP.Datos;
using SBASAWAPP.Models;

namespace SBASAWAPP.Controllers
{
    public class GRAFICOSController : Controller
    {
        private example5_SBASAWAPPEntities db = new example5_SBASAWAPPEntities();

        // GET: GRAFICOS
        public ActionResult Index()
        {
            return View(db.PROVINCIAs.ToList());
        }

        // GET: GRAFICOS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROVINCIA pROVINCIA = db.PROVINCIAs.Find(id);
            if (pROVINCIA == null)
            {
                return HttpNotFound();
            }
            return View(pROVINCIA);
        }

        // GET: GRAFICOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GRAFICOS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRol")] PROVINCIA pROVINCIA)
        {
            if (ModelState.IsValid)
            {
                db.PROVINCIAs.Add(pROVINCIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pROVINCIA);
        }

        // GET: GRAFICOS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROVINCIA pROVINCIA = db.PROVINCIAs.Find(id);
            if (pROVINCIA == null)
            {
                return HttpNotFound();
            }
            return View(pROVINCIA);
        }

        // POST: GRAFICOS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRol")] PROVINCIA pROVINCIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROVINCIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pROVINCIA);
        }

        // GET: GRAFICOS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROVINCIA pROVINCIA = db.PROVINCIAs.Find(id);
            if (pROVINCIA == null)
            {
                return HttpNotFound();
            }
            return View(pROVINCIA);
        }

        // POST: GRAFICOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PROVINCIA pROVINCIA = db.PROVINCIAs.Find(id);
            db.PROVINCIAs.Remove(pROVINCIA);
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

        [HttpGet]
        public JsonResult ReporteProductos()
        {
            DT_Reporte objDT_Reporte = new DT_Reporte();

            List<ReporteProductos> objLista = objDT_Reporte.RetornarProductos();

            return Json(objLista, JsonRequestBehavior.AllowGet);
        }

    }
}
