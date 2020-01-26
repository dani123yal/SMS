using SMS2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace SMS2.Controllers
{
    public class HomeController : Controller
    {

        SMS sms = new SMS();


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



            /* DateTime t = new DateTime(2019, 1, 1);
             DateTime t1 = new DateTime(2020, 1, 30);
             Random r = new Random();

             while (!t.Equals(t1))
             {
                 for (int i = 1; i <= 11; i++)
                 {
                     Attendance a = new Attendance()
                     {
                         att_Date = t,
                         att_Status = r.Next(0,2) == 1? "Present" : "Absent",
                         cl_ID = 2,
                         st_ID = i

                     };
                     sms.Attendances.Add(a);
                 }
                 t = t.AddDays(1);
                 //Debug.Write(t.ToShortDateString());

             }
                 sms.SaveChanges();

     */

          /*  Random r = new Random();

            for (int i = 1; i <= 11; i++)
            {
                StudentResult sr = new StudentResult()
                {
                    cl_ID = 2,
                    str_MaxMarks = 10,
                    str_MarksObt = r.Next(1, 11),
                    str_Type = "Quiz 1",
                    st_ID = i,
                    sub_ID = 1
                };

                sms.StudentResults.Add(sr);

                sr = new StudentResult()
                {
                    cl_ID = 2,
                    str_MaxMarks = 5,
                    str_MarksObt = r.Next(1, 6),
                    str_Type = "Quiz 2",
                    st_ID = i,
                    sub_ID = 1
                };
                sms.StudentResults.Add(sr);
                sr = new StudentResult()
                {
                    cl_ID = 2,
                    str_MaxMarks = 20,
                    str_MarksObt = r.Next(1, 21),
                    str_Type = "Assignemnt 1",
                    st_ID = i,
                    sub_ID = 1
                };
                sms.StudentResults.Add(sr);

            }

            for (int i = 1; i <= 11; i++)
            {
                StudentResult sr = new StudentResult()
                {
                    cl_ID = 2,
                    str_MaxMarks = 10,
                    str_MarksObt = r.Next(1, 11),
                    str_Type = "Surprise Test 1",
                    st_ID = i,
                    sub_ID = 2
                };
                sms.StudentResults.Add(sr);

                sr = new StudentResult()
                {
                    cl_ID = 2,
                    str_MaxMarks = 5,
                    str_MarksObt = r.Next(1, 6),
                    str_Type = "Quiz 1",
                    st_ID = i,
                    sub_ID = 2
                };
                sms.StudentResults.Add(sr);

                sr = new StudentResult()
                {
                    cl_ID = 2,
                    str_MaxMarks = 20,
                    str_MarksObt = r.Next(1, 21),
                    str_Type = "Assignemnt 1",
                    st_ID = i,
                    sub_ID = 2
                };
                sms.StudentResults.Add(sr);

            }

            sms.SaveChanges();
            */

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