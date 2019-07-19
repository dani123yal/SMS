using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS2.Controllers
{
    public class TimeTableController : Controller
    {
        // GET: TimeTable
        public ActionResult Index()
        {
            ViewBag.dashboardClass = "";
            ViewBag.studentResultsClass = "treeview";
            ViewBag.viewResultClass = "";
            ViewBag.addResultClass = "";
            ViewBag.attendenceClass = "treeview";
            ViewBag.markAttendenceClass = "";
            ViewBag.viewAttendenceClass = "";
            ViewBag.timetableClass = "active";
            return View();
        }
    }
}