using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AkademiPlus_Transportation.Models;
using PagedList;

namespace AkademiPlus_Transportation.Controllers
{
    public class CategoryController : Controller
    {

        DbTransportEntities db = new DbTransportEntities();

        public ActionResult Index(int sayfa = 1)
        {
            var categories = db.TblCategory.ToList().ToPagedList(sayfa, 4);
            return View(categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TblCategory category)
        {
            db.TblCategory.Add(category);
            db.SaveChanges(); //adonet--> executenonquery
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = db.TblCategory.Find(id);
            db.TblCategory.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = db.TblCategory.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TblCategory category)
        {
            var value = db.TblCategory.Find(category.CategoryID);
            value.CategoryName = category.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}