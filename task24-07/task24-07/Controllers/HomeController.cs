using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task24_07.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["logedIn"] = "false";
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
        [HttpPost]
        public ActionResult Contact(FormCollection form)
        {
            ViewBag.fullname = form["fullname"];
            ViewBag.email = form["email"];
            ViewBag.phone = form["phone"];
            ViewBag.message = form["message"];

            return View();
        }
        public ActionResult logIn()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult logIn(FormCollection form)
        {
            string email = form["email"];
            string password = form["password"];
            if (email == "ayah@gmail.com" && password == "123")
            {
                Session["logedIn"] = "true";
                return View("index");
            }

            return View("index");

        }
    }
}