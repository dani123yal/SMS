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
    public class AttendanceController : Controller
    {
        SMS sms = new SMS();
        // GET: Attendance
        public ActionResult Index()
        {
            
            return View();
            //return RedirectToAction("index","Home");
            
            
        }


        [HttpGet]
        public ActionResult MarkAttendance()
        {
            if (WebSecurity.CurrentUserId != 0)
            {
                ViewBag.dashboardClass = "";
                ViewBag.studentResultsClass = "treeview";
                ViewBag.viewResultClass = "";
                ViewBag.addResultClass = "";
                ViewBag.attendenceClass = "active treeview";
                ViewBag.markAttendenceClass = "active";


                int classId = Convert.ToInt32((from a in sms.Faculties
                                               where a.user_ID == WebSecurity.CurrentUserId
                                               select a.classTeacherOf).SingleOrDefault());

                ViewBag.classID = (from a in sms.Classes
                                  where a.cl_ID == classId
                                  select a.cl_Name).SingleOrDefault();
                //Response.Write("<script>alert(" + ViewBag.classID + ");</script>");
                var studentList = (from a in sms.Students
                                   where a.cl_ID == classId
                                   select a).ToList();
                //Response.Write("<script>alert("+studentList.Count+");</script>");

                AttendanceModel att = new AttendanceModel();
                att.attendanceList = new List<AttendanceModel>();

                att.classId = classId;
                foreach(var student in studentList)
                {
                    att.attendanceList.Add(new AttendanceModel
                    {
                        attendance = new Attendance {

                        },
                        studentList = new Student
                        {
                            st_ID = student.st_ID,
                            st_Name = student.st_Name,
                            st_Age = student.st_Age,
                            st_Phone = student.st_Phone,
                            st_FatherName = student.st_FatherName
                        }
                    });
                }

                att.attendance = new Attendance
                {
                    att_ID = 3,
                    att_Date = DateTime.Now,
                    att_Status = "present"
                };


                return View(att);
            }

            return View();
        }

        [HttpPost]
        public ActionResult MarkAttendance(AttendanceModel model, FormCollection form)
        {

            ViewBag.dashboardClass = "";
            ViewBag.studentResultsClass = "treeview";
            ViewBag.viewResultClass = "";
            ViewBag.addResultClass = "";
            ViewBag.attendenceClass = "active treeview";
            ViewBag.markAttendenceClass = "active";


            DateTime today = Convert.ToDateTime(form["date"]);

            if (checkIfAttExist(today, model.classId))
            {
                foreach(AttendanceModel a in model.attendanceList)
                {
                    if (a.attStatus)
                    {
                        a.attendance.att_Status = "Present";
                    }
                    else
                    {
                        a.attendance.att_Status = "Absent";
                    }
                    a.attendance.att_Date = today;
                    a.attendance.cl_ID = model.classId;
                    a.attendance.st_ID = a.studentList.st_ID;

                    sms.Attendances.Add(a.attendance);
                }

                sms.SaveChanges();
            }

            return View("Index","Home");
        }

        public bool checkIfAttExist(DateTime date, int classId)
        {

            var data = from a in sms.Attendances
                       where a.att_Date == date
                       && a.cl_ID == classId
                       select a;

            int i = 0;
            foreach(Attendance a in data)
            {
                i++;
            }
            if(i > 0)
            {
                return false;
            }

            return true;
        }

    }
}