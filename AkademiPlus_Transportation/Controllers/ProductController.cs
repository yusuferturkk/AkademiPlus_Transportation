using AkademiPlus_Transportation.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkademiPlus_Transportation.Controllers
{
    public class ProductController : Controller
    {

        DbTransportEntities db = new DbTransportEntities();

        public ActionResult Index(int sayfa = 1)
        {
            var values = db.TblProduct.ToList().ToPagedList(sayfa, 4);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> values = (from x in db.TblCategory
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(TblProduct tblProduct)
        {
            db.TblProduct.Add(tblProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var value = db.TblProduct.Find(id);
            db.TblProduct.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var value = db.TblProduct.Find(id);

            List<SelectListItem> values = (from i in db.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.CategoryID.ToString()
                                           }).ToList();
            ViewBag.value = values;

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProduct(TblProduct tblProduct)
        {
            var value = db.TblProduct.Find(tblProduct.ProductID);

            var category = db.TblCategory.Where(m => m.CategoryID == tblProduct.CategoryID).FirstOrDefault();
            value.CategoryID = category.CategoryID;

            value.ProductName = tblProduct.ProductName;
            value.ProductSizeType = tblProduct.ProductSizeType;
            value.ProductSize = tblProduct.ProductSize;
            value.ProductDescription = tblProduct.ProductDescription;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}