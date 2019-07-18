using SMS2.Models;
using SMS2.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace SMS2.Controllers
{
    public class StudentResultController : Controller
    {

        

        SMS sms = new SMS();

        // GET: StudentResult
        public ActionResult AddResult()
        {
            ViewBag.dashboardClass = "";
            ViewBag.studentResultsClass = "active treeview";
            ViewBag.viewResultClass = "";
            ViewBag.addResultClass = "active";

            Faculty faculty = (from a in sms.Faculties where a.user_ID == WebSecurity.CurrentUserId select a).First();

            return View(faculty);
        }

        [HttpGet]
        public ActionResult addResultInside(int subj_id)
        {
            Session["subj_id"] = subj_id;
            ViewBag.dashboardClass = "";
            ViewBag.studentResultsClass = "active treeview";
            ViewBag.viewResultClass = "";
            ViewBag.addResultClass = "active";

            int? classID = (from a in sms.Subjects where a.sub_ID == subj_id select a.cl_ID).First();

            Session["classID"] = classID;

            StudentStudentResultViewModel viewModel = new StudentStudentResultViewModel();

            viewModel.studentResultview = new StudentResult();
            viewModel.studentsview = (from a in sms.Students where a.cl_ID == classID select a).ToList();

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult addResultInside(StudentStudentResultViewModel abc)
        {
            abc.studentResultview.sub_ID = int.Parse( Session["subj_id"].ToString());
            abc.studentResultview.cl_ID = int.Parse(Session["classID"].ToString());

            sms.StudentResults.Add(abc.studentResultview);

            sms.SaveChanges();


            return RedirectToAction("Index","Home");
        }


        public ActionResult viewResult()
        {
            ViewBag.dashboardClass = "";
            ViewBag.studentResultsClass = "active treeview";

            ViewBag.viewResultClass = "active";
            ViewBag.addResultClass = "";

            Faculty faculty = (from a in sms.Faculties where a.user_ID == WebSecurity.CurrentUserId select a).First();

            return View(faculty);
        }


        public ActionResult viewResultInside(int subj_id)
        {
            ViewBag.dashboardClass = "";
            ViewBag.studentResultsClass = "active treeview";
            ViewBag.viewResultClass = "active";
            ViewBag.addResultClass = "";

            var studentResult = (from a in sms.StudentResults where a.sub_ID == subj_id select a).ToList();

            string subjectName = (from a in sms.Subjects where a.sub_ID == subj_id select a.sub_Name).First();

            ViewBag.subj_name = subjectName;

            return View(studentResult);
        }

    }
}