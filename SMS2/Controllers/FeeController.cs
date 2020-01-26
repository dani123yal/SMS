using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace SMS2.Controllers
{
    public class FeeController : Controller
    {
        // GET: Fee
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

                if (WebSecurity.CurrentUserId != 13)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            ViewBag.feeClass = "active";
            return View();
        }


        public ActionResult printInvoice()
        {
            return View();
        }
    }
}