using SMS2.Models;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;



namespace MvcMembershipApp.Controllers

{

    public class AccountController : Controller

    {

        //

        // GET: /Account/

        SMS sms = new SMS();

        public ActionResult Index()

        {

            return View();

        }



        [HttpGet]

        public ActionResult Login()

        {

            if (!WebSecurity.Initialized)

            {

                WebSecurity.InitializeDatabaseConnection("SMS2", "Users", "ID", "Name", autoCreateTables: true);

            }



            return View();

        }



        [HttpPost]

        public ActionResult Login(FormCollection Form)

        {

            bool Authenticated = WebSecurity.Login(Form["UserName"], Form["Password"], false);

            string username = Form["UserName"];

            if (Authenticated)

            {

                string Return_Url = Request.QueryString["ReturnUrl"];

                if (Return_Url == null)

                {

                    Response.Redirect("/Home/Index");

                }

                else

                {

                    Response.Redirect(Return_Url);

                }

            }

            return View();

        }



        [HttpGet]

        public ActionResult Register()

        {

            if (!WebSecurity.Initialized)

            {

                WebSecurity.InitializeDatabaseConnection("SMS2", "Users", "UserID", "UserName", autoCreateTables: true);

            }

            string username = "aishah.tuf7@gmail.com";
            string password = "12345";

            Faculty faculty = new Faculty();
            faculty.fac_Name = "Aishah Tufail";
            faculty.fac_CNIC = "44206-1285452-5";
            faculty.fac_phoneNo = "030013231231";
            faculty.fac_Salary = 100000;
            

            WebSecurity.CreateUserAndAccount(username, password);
            Roles.AddUserToRole(username, "Faculty");
            faculty.user_ID = WebSecurity.GetUserId(username);

            sms.Faculties.Add(faculty);
            sms.SaveChanges();
            
            return RedirectToAction("Index", "Home");

        }



        [HttpPost]

        public ActionResult Register(FormCollection Form)

        {

            WebSecurity.CreateUserAndAccount(Form["Name"], Form["Password"]);
            Roles.AddUserToRole(Form["Name"], "Faculty");
            Response.Redirect("~/Account/Login");

            return View();

        }



        public ActionResult Logout()

        {

            WebSecurity.Logout();

            Response.Redirect("~/Account/Login");

            return View();

        }

    }

}