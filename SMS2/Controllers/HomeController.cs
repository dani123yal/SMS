using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace SMS2.Controllers
{
    public class HomeController : Controller
    {

        


        public ActionResult Index()
        {
            if (!WebSecurity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (!Roles.GetRolesForUser(WebSecurity.CurrentUserName)[0].Equals("Faculty"))
                {
                    
                    return RedirectToAction("Login", "Account");
                }
            }
            
            ViewBag.dashboardClass = "active";
            ViewBag.studentResultsClass = "treeview";
            ViewBag.viewResultClass = "";
            ViewBag.addResultClass = "";
            ViewBag.attendenceClass = "treeview";
            ViewBag.markAttendenceClass = "";
            ViewBag.viewAttendenceClass = "";


            return View();
        }

        public ActionResult IndexStudent()
        {
            if (!WebSecurity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (!Roles.GetRolesForUser(WebSecurity.CurrentUserName)[0].Equals("Student"))
                {

                    return RedirectToAction("Login", "Account");
                }
            }

            //ViewBag.dashboardClass = "active";
            //ViewBag.studentResultsClass = "treeview";
            //ViewBag.viewResultClass = "";
            //ViewBag.addResultClass = "";
            //ViewBag.attendenceClass = "treeview";
            //ViewBag.markAttendenceClass = "";
            ViewBag.dashboardClass = "active";
            ViewBag.resultClass = "";

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