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
    public class HomeController : Controller
    {
        private example5_SBASAWAPPEntities db = new example5_SBASAWAPPEntities();
        public ActionResult Index()
        {
            var nOTIFICATIONS = db.NOTIFICATIONS.Include(n => n.AspNetUser);
            return View(nOTIFICATIONS.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}