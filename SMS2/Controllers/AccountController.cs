using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;



namespace MvcMembershipApp.Controllers

{

    public class AccountController : Controller

    {

        //

        // GET: /Account/



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

            string username = "mohammadaashir9@gmail.com";
            string password = "123456";

            WebSecurity.CreateUserAndAccount(username, password);
            Roles.AddUserToRole(username, "Faculty");
            
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