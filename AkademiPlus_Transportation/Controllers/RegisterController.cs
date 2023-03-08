﻿using AkademiPlus_Transportation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkademiPlus_Transportation.Controllers
{
    public class RegisterController : Controller
    {
        
        DbTransportEntities db = new DbTransportEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin tblAdmin)
        {
            db.TblAdmin.Add(tblAdmin);
            db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}