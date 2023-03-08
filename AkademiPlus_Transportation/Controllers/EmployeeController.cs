using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AkademiPlus_Transportation.Models;
using PagedList;

namespace AkademiPlus_Transportation.Controllers
{
    public class EmployeeController : Controller
    {

        DbTransportEntities db = new DbTransportEntities();

        public ActionResult Index(int sayfa = 1)
        {
            var values = db.TblEmployee.ToList().ToPagedList(sayfa, 4);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(TblEmployee employee)
        {
            db.TblEmployee.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEmployee(int id)
        {
            var employee = db.TblEmployee.Find(id);
            db.TblEmployee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            var value = db.TblEmployee.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(TblEmployee employee)
        {
            var value = db.TblEmployee.Find(employee.EmployeeID);
            value.EmployeeName = employee.EmployeeName;
            value.EmployeeSurname = employee.EmployeeSurname;
            value.EmployeeImage = employee.EmployeeImage;
            value.EmployeeDescription = employee.EmployeeDescription;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}