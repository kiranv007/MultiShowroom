using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiShowroom.Controllers
{
    public class xunittestController : Controller
    {
        // GET: xunittest
        public ActionResult Index()
        {
            ViewBag.Sample = "Yash";
            return View();
        }
    }
}