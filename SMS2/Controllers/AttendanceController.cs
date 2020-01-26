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

            if (WebSecurity.CurrentUserId != 0)
            {
                ViewBag.dashboardClass = "";
                ViewBag.studentResultsClass = "treeview";
                ViewBag.viewResultClass = "";
                ViewBag.addResultClass = "";
                ViewBag.attendenceClass = "active treeview";
                ViewBag.markAttendenceClass = "active";
                ViewBag.viewAttendenceClass = "";

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
                foreach (var student in studentList)
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
            ViewBag.viewAttendenceClass = "";

            DateTime today = Convert.ToDateTime(form["date"]);

            if (checkIfAttExist(today, model.classId))
            {
                foreach (AttendanceModel a in model.attendanceList)
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
                TempData["isMarked"] = true;
            }
            else
            {
                TempData["isMarked"] = false;
            }

            TempData["fromAttendance"] = true;

            return RedirectToAction("Index", "Home");
        }

        public bool checkIfAttExist(DateTime date, int classId)
        {

            var data = from a in sms.Attendances
                       where a.att_Date == date
                       && a.cl_ID == classId
                       select a;

            int i = 0;
            foreach (Attendance a in data)
            {
                i++;
            }
            if (i > 0)
            {
                return false;
            }

            return true;
        }


        [HttpGet]
        public ActionResult ViewAttendance()
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

            ViewBag.dashboardClass = "";
            ViewBag.studentResultsClass = "treeview";
            ViewBag.viewResultClass = "";
            ViewBag.addResultClass = "";
            ViewBag.attendenceClass = "active treeview";
            ViewBag.markAttendenceClass = "";
            ViewBag.viewAttendenceClass = "active";

            if (WebSecurity.CurrentUserId != 0)
            {

                int classId = Convert.ToInt32((from a in sms.Faculties
                                               where a.user_ID == WebSecurity.CurrentUserId
                                               select a.classTeacherOf).SingleOrDefault());


                ViewBag.classID = (from a in sms.Classes
                                   where a.cl_ID == classId
                                   select a.cl_Name).SingleOrDefault();




                //Response.Write("<script>alert("+studentList.Count+");</script>");


                AttendanceModel att = new AttendanceModel();

                att.classId = classId;

                return View(att);
            }
            return View(new AttendanceModel());
        }

        [HttpPost]
        public ActionResult ViewAttendance(AttendanceModel attendance, FormCollection form)
        {
            string da = form["date"];
            DateTime date = DateTime.ParseExact(da, "MM/dd/yyyy", null);

            return RedirectToAction("AttendanceDetails","Attendance", new { classId = attendance.classId, date = date});
        }


        [HttpGet]
        public ActionResult AttendanceDetails(int classId, DateTime date)
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

            ViewBag.dashboardClass = "";
            ViewBag.studentResultsClass = "treeview";
            ViewBag.viewResultClass = "";
            ViewBag.addResultClass = "";
            ViewBag.attendenceClass = "active treeview";
            ViewBag.markAttendenceClass = "";
            ViewBag.viewAttendenceClass = "active";

            AttendanceModel att = new AttendanceModel();

            att.attendanceList = new List<AttendanceModel>();

            var attendanceList = (from a in sms.Attendances
                                  where a.att_Date == date
                                  && a.cl_ID == classId
                                  select a).ToList();

            ViewBag.classID = (from a in sms.Classes
                               where a.cl_ID == classId
                               select a.cl_Name).SingleOrDefault();

            ViewBag.date = date.ToShortDateString();

            foreach (Attendance student in attendanceList)
            {
                Student st = getStudent(student.st_ID);
                att.attendanceList.Add(new AttendanceModel
                {
                    attendance = new Attendance
                    {
                        att_Date = student.att_Date,
                        cl_ID = student.cl_ID,
                        att_Status = student.att_Status
                    },
                    studentList = new Student
                    {
                        st_ID = st.st_ID,
                        st_Name = st.st_Name,
                    }
                });
            }

            return View(att);
        }

        [HttpPost]
        public ActionResult AttendanceDetails()
        {

            return View();
        }


        public Student getStudent(int? id)
        {
            Student st = (from a in sms.Students
                             where a.st_ID == id
                             select a).FirstOrDefault();

            if(st != null)
            {
                return st;
            }

            return null;
        }
    }
}