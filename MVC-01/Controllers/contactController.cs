﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_01.Controllers
{
    public class contactController : Controller
    {
        // GET: contact
        public ActionResult Index()
        {
            return View();
        }
    }
}