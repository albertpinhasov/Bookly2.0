using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookly.Controllers
{
    public class HomeController : Controller
    {
       
       // [Route("home/index")]
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Index(int id)
        //{
        //    return Content("Id=" + id);
        //    //return HttpNotFound();
        //    //return RedirectToAction("About", new { book = "Intelligent Investor", priority = 2});
        //    //return View();
        //}

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