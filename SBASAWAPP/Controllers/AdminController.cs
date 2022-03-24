using OfficeOpenXml;
using SBASAWAPP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBASAWAPP.Controllers
{
    public class AdminController : Controller
    {
        private example5_SBASAWAPPEntities db = new example5_SBASAWAPPEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult STATS()
        {
            var stream = new MemoryStream();

            var query = from a in db.PRODUCTS
                        join b in db.PRODUCTSPS on a.ID equals b.ID_PRODUCT
                        select new joinModel
                        {
                            NAME = a.NAME,
                            QUANTITY = b.QUANTITY
                        };


            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sales");
                worksheet.Cells.LoadFromCollection(query.ToList());
                package.Save();
            }

            stream.Position = 0;
            string excelName = $"SALES-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            return File(stream, "application/octet-stream", excelName);
        }
    }
}
