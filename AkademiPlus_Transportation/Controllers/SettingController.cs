using AkademiPlus_Transportation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkademiPlus_Transportation.Controllers
{
    public class SettingController : Controller
    {
        
        DbTransportEntities db = new DbTransportEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var values = Session["UserName"];
            var userValue = db.TblAdmin.Where(a => a.UserName == values).FirstOrDefault();
            return View(userValue);
        }

        [HttpPost]
        public ActionResult Index(TblAbout tblAdmin)
        {
            return View();
        }
    }
}