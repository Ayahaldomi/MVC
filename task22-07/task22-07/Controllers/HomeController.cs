using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task22_07.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "this is my second page";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "this is my third page";

            return View();
        }
        public ActionResult services()
        {
            ViewBag.Message = "this is my fourth page";

            return View();
        }
        public ActionResult results()
        {
            ViewBag.Message = "this is my third page";

            return View();
        }
    }
}