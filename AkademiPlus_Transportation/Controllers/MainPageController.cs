using AkademiPlus_Transportation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkademiPlus_Transportation.Controllers
{
    public class MainPageController : Controller
    {

        DbTransportEntities db = new DbTransportEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialSlider()
        {
            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialDetail()
        {
            ViewBag.leftSmallTitle = "Güvenli Taşımacılık";
            ViewBag.leftLargeTitle = "Dünyanın Her Yerine Tüm Kargolar";
            ViewBag.leftContent = "Konumu fark etmeksizin, doğudan batıya, kuzeyden güneye en uzak noktalara uzman ekibimizle güvenli teslimat yapıyoruz";

            ViewBag.rightTitle1 = "Taşıma Kolaylığı";
            ViewBag.rightContent1 = "Kendi ambalajlarımızla ile kargolarınızı paketliyoruz.";

            ViewBag.rightTitle2 = "Şehir İçi Dağıtım";
            ViewBag.rightContent2 = "İstediğiniz saatte evlerinize veya belirlediğiniz yere teslimat yapmaktayız.";
            return PartialView();
        }

        public PartialViewResult PartialMap()
        {
            return PartialView();
        }

        public PartialViewResult PartialFeatures()
        {
            return PartialView();
        }

        public PartialViewResult PartialGrids()
        {
            return PartialView();
        }

        public PartialViewResult PartialTestimonials()
        {
            return PartialView();
        }

        public PartialViewResult PartialNewsletter()
        {
            return PartialView();
        }
    }
}