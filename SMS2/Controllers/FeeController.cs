using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS2.Controllers
{
    public class FeeController : Controller
    {
        // GET: Fee
        public ActionResult Index()
        {

            ViewBag.feeClass = "active";
            return View();
        }


        public ActionResult printInvoice()
        {
            return View();
        }
    }
}