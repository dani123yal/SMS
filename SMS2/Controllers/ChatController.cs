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
            return View();
        }


        [HttpGet]
        public ActionResult Create(int id)
        {
            return View();
        }



        [HttpGet]
        public ActionResult ParentIndex()
        {
            return View();
        }
    }
}