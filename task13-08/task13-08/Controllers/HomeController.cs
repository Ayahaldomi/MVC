using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task13_08.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string price, string image)
        {
            List<string> myListName = Session["myListName"] as List<string>;
            List<string> myListPrice = Session["myListPrice"] as List<string>;
            List<string> myListImage = Session["myListImage"] as List<string>;
            if (myListName != null)
            {
                myListName.Add(name);
                myListPrice.Add(price);
                myListImage.Add(image);

            }
            else
            {
                myListName = new List<string> { name };
                myListPrice = new List<string> { price };
                myListImage = new List<string> { image };
            }
            Session["myListName"] = myListName;
            Session["myListPrice"] = myListPrice;
            Session["myListImage"] = myListImage;

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
    }
}