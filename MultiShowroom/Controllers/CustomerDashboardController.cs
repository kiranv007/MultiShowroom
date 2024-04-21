using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiShowroom.Controllers
{
    public class CustomerDashboardController : Controller
    {
        // GET: CustomerDashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}