using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS2.Controllers
{
    public class HomeController : Controller
    {

        


        public ActionResult Index()
        {
            
            ViewBag.dashboardClass = "active";
            ViewBag.studentResultsClass = "treeview";
            ViewBag.viewResultClass = "";
            ViewBag.addResultClass = "";
            ViewBag.attendenceClass = "treeview";
            ViewBag.markAttendenceClass = "";


            return View();
        }

        public ActionResult IndexStudent()
        {

            //ViewBag.dashboardClass = "active";
            //ViewBag.studentResultsClass = "treeview";
            //ViewBag.viewResultClass = "";
            //ViewBag.addResultClass = "";
            //ViewBag.attendenceClass = "treeview";
            //ViewBag.markAttendenceClass = "";


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