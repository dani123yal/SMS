using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS2.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {

           ViewBag.studentResultsClass = "treeview";
            ViewBag.attendenceClass =  "treeview";
            ViewBag.markAttendenceClass = "";
            ViewBag.commentClass = "active"; 
            return View();
        }


        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag.studentResultsClass = "treeview";
            ViewBag.attendenceClass = "treeview";
            ViewBag.markAttendenceClass = "";
            ViewBag.commentClass = "active";
            return View();
        }



        [HttpGet]
        public ActionResult ParentIndex()
        {
            ViewBag.commentClass = "active";
            return View();
        }
    }
}