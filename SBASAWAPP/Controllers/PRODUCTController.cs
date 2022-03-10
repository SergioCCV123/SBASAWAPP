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
    public class PRODUCTController : Controller
    {
        private example5_SBASAWAPPEntities db = new example5_SBASAWAPPEntities();

        // GET: PRODUCT
        public ActionResult Index()
        {

            List<Models.CategoriesViewModels> lst = null;

            lst = (from d in db.CATEGORIES
                   select new Models.CategoriesViewModels
                   {
                       ID = d.ID,
                       CATEGORY_NAME = d.CATEGORY_NAME
                   }).ToList();

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.CATEGORY_NAME.ToString(),
                    Value = d.ID.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;

            var pRODUCTS = db.PRODUCTS.Include(p => p.CATEGORIES);
            return View(pRODUCTS.ToList());
        }

        // GET: PRODUCT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: PRODUCT/Create
        public ActionResult Create()
        {
            ViewBag.CATEGORY = new SelectList(db.CATEGORIES, "ID", "CATEGORY_NAME");
            return View();
        }

        // POST: PRODUCT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,DESCRIPTION,PRICE,URL,CATEGORY")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTS.Add(pRODUCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CATEGORY = new SelectList(db.CATEGORIES, "ID", "CATEGORY_NAME", pRODUCT.CATEGORY);
            return View(pRODUCT);
        }

        // GET: PRODUCT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.CATEGORY = new SelectList(db.CATEGORIES, "ID", "CATEGORY_NAME", pRODUCT.CATEGORY);
            return View(pRODUCT);
        }

        // POST: PRODUCT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,DESCRIPTION,PRICE,URL,CATEGORY")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CATEGORY = new SelectList(db.CATEGORIES, "ID", "CATEGORY_NAME", pRODUCT.CATEGORY);
            return View(pRODUCT);
        }

        // GET: PRODUCT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // POST: PRODUCT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            db.PRODUCTS.Remove(pRODUCT);
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
