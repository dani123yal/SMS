using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS2.Models;
using SMS2.ViewModel;
using System.Web.Security;
using WebMatrix.WebData;


namespace SMS2.Controllers
{
    public class AttendanceForStudentController : Controller
    {
        SMS sms = new SMS();

        // GET: AttendanceForStudent
        public ActionResult Index()
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

            if (WebSecurity.CurrentUserId != 0)
            {
                ViewBag.dashboardClass = "";
                ViewBag.studentResultsClass = "treeview";
                ViewBag.viewResultClass = "";
                ViewBag.addResultClass = "";
                ViewBag.attendenceClass = "active treeview";
                ViewBag.markAttendenceClass = "";
                ViewBag.attendenceClass = "active";
                return View();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            int month = Convert.ToInt32(form["month"]);

            return RedirectToAction("viewStudentAttendance", "AttendanceForStudent", new { month = month});
        }


        [HttpGet]
        public ActionResult viewStudentAttendance(int month)
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


            ViewBag.dashboardClass = "";
            ViewBag.studentResultsClass = "treeview";
            ViewBag.viewResultClass = "";
            ViewBag.addResultClass = "";
            ViewBag.attendenceClass = "active treeview";
            ViewBag.markAttendenceClass = "";
            ViewBag.attendenceClass = "active";

            Student st = (from a in sms.Students
                          where a.user_ID == WebSecurity.CurrentUserId
                          select a).SingleOrDefault();


            var attendanceList = (from a in sms.Attendances
                                  where a.st_ID == st.st_ID
                                  && a.cl_ID == st.cl_ID
                                  && a.att_Date.Value.Month == month
                                  select a).ToList();

            StudentAttendanceModel stModel = new StudentAttendanceModel();
            //return Content(attendanceList.Count.ToString());  

            DateTime forMonth = new DateTime(1, month, 1);
            ViewBag.month = forMonth.ToString("MMMMMMMMMM");

            stModel.student = st;
            stModel.AttendanceList = attendanceList;
            //stModel.AttendanceList.Reverse();
            return View(stModel);
        }




    }
}