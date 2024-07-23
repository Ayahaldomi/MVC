using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task23_07.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ContactView()
        {
            

            return View();
        }
        [HttpPost]

        public ActionResult Contact(FormCollection form)
        {
            TempData["textInput"] = form["textInput"];
            TempData["numberInput"] = form["numberInput"];
            TempData["radioOptions"] = form["radioOptions"];
            TempData["multiSelectInput"] = form["multiSelectInput"];

            return View("ContactView");
        }
    }
}