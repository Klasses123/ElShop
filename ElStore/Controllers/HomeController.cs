using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Интернет - магазин, предназначен для изучения платформы ASP.NET.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контактная инофрмация";

            return View();
        }
    }
}