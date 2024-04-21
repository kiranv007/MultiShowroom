using MultiShowroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MultiShowroom.Controllers
{
    //[Authorize]
    public class AdminLoginController : Controller
    {
        TatabaseEntities db=new TatabaseEntities();
        // GET: AdminLogin
        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult Index(Admin log)
        {
            try
            {
                var Admin = db.Admins.Where(x => x.Username == log.Username && x.Password == log.Password).Count();
               
                if (Admin > 0)
                {   
                    return Redirect("/AdminsDashboard/Index");
                }
                //else
                //{
                //    return View();
                //}

            }
            catch (Exception)
            {
                throw new Exception("Error while checking admin details");
               

            }
            return View();




        }
    }
}