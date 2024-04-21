using MultiShowroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiShowroom.Controllers
{
    public class CustloginController : Controller
    { TatabaseEntities db=new TatabaseEntities();
        // GET: Custlogin
        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult Index(CustomerDetail log)
        {
            var Admin = db.CustomerDetails.Where(x => x.UserName == log.UserName && x.Password == log.Password).Count();
            if (Admin > 0)
            {
                return Redirect("/CustomerDashBoard/Index");
            }
            else
            {
                return View();
            }



        }
    }
}