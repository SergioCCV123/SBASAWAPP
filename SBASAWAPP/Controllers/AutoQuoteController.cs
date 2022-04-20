using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SBASAWAPP.Models;

namespace SBASAWAPP.Controllers
{
    public class AutoQuoteController : Controller
    {
        // GET: AutoQuote
        public ActionResult Index()
        {
            List<SelectListItem> Stories = new List<SelectListItem>();
            Stories.Add(new SelectListItem { Text = "1", Value = "1" });
            Stories.Add(new SelectListItem { Text = "2", Value = "2" });
            ViewBag.Stories = Stories;
            List<SelectListItem> Bath = new List<SelectListItem>();
            Bath.Add(new SelectListItem { Text = "1", Value = "1" });
            Bath.Add(new SelectListItem { Text = "2-3", Value = "2" });
            ViewBag.Baths = Bath;
            return View();
        }

        public void Bomba(QuoteViewModel model)
        {
            if(model.Pisos.Equals("1") && model.Baths.Equals("1"))
            {
                Response.Redirect("https://bombasarcor.co.cr/Files/2.pdf");
            }else if (model.Baths.Equals("2"))
            {
                Response.Redirect("https://bombasarcor.co.cr/Files/2.pdf");
            }
            else
            {
                Response.Redirect("~/AutoQuoteController/Index");
            }
        }
    }
}