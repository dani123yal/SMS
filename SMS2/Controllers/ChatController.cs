using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace SMS2.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
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

            ViewBag.studentResultsClass = "treeview";
            ViewBag.attendenceClass =  "treeview";
            ViewBag.markAttendenceClass = "";
            ViewBag.commentClass = "active"; 
            return View();
        }


        [HttpGet]
        public ActionResult Create(int id)
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

            ViewBag.studentResultsClass = "treeview";
            ViewBag.attendenceClass = "treeview";
            ViewBag.markAttendenceClass = "";
            ViewBag.commentClass = "active";
            return View();
        }



        [HttpGet]
        public ActionResult ParentIndex()
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

                if(WebSecurity.CurrentUserId != 13)
                {
                    return RedirectToAction("Login", "Account");
                }
            }

            ViewBag.commentClass = "active";
            return View();
        }
    }
}