using HomeStayWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeStayWeb.Controllers
{
    public class HomeController : Controller
    {
        private homestayEntities2 db = new homestayEntities2();
        public ActionResult Index()
        {
            return View(db.Phongs.ToList());
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
        public ActionResult Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}