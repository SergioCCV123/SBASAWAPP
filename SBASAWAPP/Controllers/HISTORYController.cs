using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SBASAWAPP;

namespace SBASAWAPP.Controllers
{
    public class HISTORYController : Controller
    {
        private example5_SBASAWAPPEntities db = new example5_SBASAWAPPEntities();

        // GET: HISTORY
        public ActionResult Index()
        {
            var hISTORY = db.HISTORY.Include(h => h.AspNetUsers).Include(h => h.PRODUCTS);
            return View(hISTORY.ToList());
        }

        // GET: HISTORY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORY hISTORY = db.HISTORY.Find(id);
            if (hISTORY == null)
            {
                return HttpNotFound();
            }
            return View(hISTORY);
        }

        // GET: HISTORY/Create
        public ActionResult Create(int? id)
        {
            PRODUCTS producto = db.PRODUCTS.Find(id);
            String result = GetID();
            AspNetUsers usuario = db.AspNetUsers.Find(result);

            ViewBag.IDUSER = new SelectList(db.AspNetUsers, "Id", "Id", result);
            ViewBag.IDPRODUCT = new SelectList(db.PRODUCTS, "ID", "ID", producto.ID);
            return View();
        }

        // POST: HISTORY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHISTORY,IDPRODUCT,IDUSER,FECHAHISTORY")] HISTORY hISTORY)
        {
            if (ModelState.IsValid)
            {
                db.HISTORY.Add(hISTORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDUSER = new SelectList(db.AspNetUsers, "Id", "Email", hISTORY.IDUSER);
            ViewBag.IDPRODUCT = new SelectList(db.PRODUCTS, "ID", "NAME", hISTORY.IDPRODUCT);
            return View(hISTORY);
        }

        // GET: HISTORY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORY hISTORY = db.HISTORY.Find(id);
            if (hISTORY == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDUSER = new SelectList(db.AspNetUsers, "Id", "Email", hISTORY.IDUSER);
            ViewBag.IDPRODUCT = new SelectList(db.PRODUCTS, "ID", "NAME", hISTORY.IDPRODUCT);
            return View(hISTORY);
        }

        // POST: HISTORY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHISTORY,IDPRODUCT,IDUSER,FECHAHISTORY")] HISTORY hISTORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hISTORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDUSER = new SelectList(db.AspNetUsers, "Id", "Email", hISTORY.IDUSER);
            ViewBag.IDPRODUCT = new SelectList(db.PRODUCTS, "ID", "NAME", hISTORY.IDPRODUCT);
            return View(hISTORY);
        }

        // GET: HISTORY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORY hISTORY = db.HISTORY.Find(id);
            if (hISTORY == null)
            {
                return HttpNotFound();
            }
            return View(hISTORY);
        }

        // POST: HISTORY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HISTORY hISTORY = db.HISTORY.Find(id);
            db.HISTORY.Remove(hISTORY);
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

        public string GetID()
        {
            String result = "";
            String username = User.Identity.Name;
            System.Data.SqlClient.SqlConnection conn = new SqlConnection("data source=wdb4.my-hosting-panel.com;initial catalog=example5_SBASAWAPP;user id=example5_ADMIN;password=SistemasDeBombeoArcorSA2022_;MultipleActiveResultSets=True;App=EntityFramework");
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT Id FROM AspNetUsers WHERE UserName=@username", conn);
                query.Parameters.AddWithValue("@username", username);
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = reader["Id"].ToString();
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return err.ToString();
            }
            finally
            {
                conn.Close();
            }
            return result;
        }


    }
}
