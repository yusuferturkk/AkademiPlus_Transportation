using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AkademiPlus_Transportation.Models;
using PagedList;

namespace AkademiPlus_Transportation.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        
        DbTransportEntities db = new DbTransportEntities();

        public ActionResult Index(int sayfa = 1)
        {
            var values = db.TblCustomer.ToList().ToPagedList(sayfa, 4);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(TblCustomer customer)
        {
            db.TblCustomer.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var value = db.TblCustomer.Find(id);
            db.TblCustomer.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCustomer(int id)
        {
            var value = db.TblCustomer.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(TblCustomer customer)
        {
            var value = db.TblCustomer.Find(customer.CustomerID);
            value.CustomerName = customer.CustomerName;
            value.CustomerSurname = customer.CustomerSurname;
            value.CustomerCity = customer.CustomerCity;
            value.CustomerPhone = customer.CustomerPhone;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}