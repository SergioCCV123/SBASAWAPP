using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OfficeOpenXml;
using SBASAWAPP;
using Syncfusion.XlsIO;

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
            SALE sALES = db.SALES.Find(id);
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
        public ActionResult Create([Bind(Include = "ID,CLIENT_NAME,SALE_TOTAL")] SALE sALES)
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
            SALE sALES = db.SALES.Find(id);
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
        public ActionResult Edit([Bind(Include = "ID,CLIENT_NAME,SALE_TOTAL")] SALE sALES)
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
            SALE sALES = db.SALES.Find(id);
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
            SALE sALES = db.SALES.Find(id);
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

        public ActionResult Excel()
        {
            var list = new List<SALE>();
            list = db.SALES.ToList();
            var stream = new MemoryStream();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sales");
                worksheet.Cells.LoadFromCollection(list);
                worksheet.Column(4).Hidden = true;
                package.Save();
            }

            stream.Position = 0;
            string excelName = $"SALES-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            return File(stream, "application/octet-stream", excelName);

        }
    }
}
