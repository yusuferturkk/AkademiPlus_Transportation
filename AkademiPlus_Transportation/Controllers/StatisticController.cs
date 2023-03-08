using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AkademiPlus_Transportation.Models;

namespace AkademiPlus_Transportation.Controllers
{
    public class StatisticController : Controller
    {
        
        DbTransportEntities db = new DbTransportEntities();

        public ActionResult Index()
        {
            //Viewbag - Viewdata - Tempdata
            var value = db.TblCustomer.Count();
            ViewBag.v1 = value;
            ViewBag.cityAnkara = db.TblCustomer.Where(c => c.CustomerCity == "Ankara").Count();
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.citySelect = db.TblCustomer.Where(c => c.CustomerID == 1).Select(y => y.CustomerID).ToList();
            ViewBag.cityCount = db.TblCustomer.Distinct().Count();

            return View();
        }
    }
}