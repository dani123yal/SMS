using SMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace SMS2.Controllers
{
    public class StudentResultStudentController : Controller
    {

        SMS sms = new SMS();

        public ActionResult ViewResult()
        {
            ViewBag.dashboardClass = "";
            ViewBag.resultClass = "active";

            Student student = (from a in sms.Students where a.user_ID == WebSecurity.CurrentUserId select a).First();

            

            return View(student);
        }

        public ActionResult viewResultInside(int subj_id)
        {
            ViewBag.dashboardClass = "";
            ViewBag.resultClass = "active";
            List<StudentResult> studentResults = (from a in sms.StudentResults where a.st_ID == WebSecurity.CurrentUserId && a.sub_ID == subj_id select a).ToList();

           

            return View(studentResults);
        }
    }
}