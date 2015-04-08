﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Book_List()
        {
            ViewBag.Message = "Your search page.";
            return View();
        }
        public ActionResult Search()
        {
            ViewBag.Message = "Your search page.";
            return View();
        }

        public ActionResult Galery()
        {
            ViewBag.Message = "Your galery page.";
            return View();
        }
        



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
