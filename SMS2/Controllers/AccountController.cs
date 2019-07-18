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

            #region Faculty Registration


            /*string username = "daniyalsafdar9@gmail.com";
            string password = "123456";

            Faculty faculty = new Faculty();
            faculty.fac_Name = "Daniyal Safdar";
            faculty.fac_CNIC = "44206-1285380-5";
            faculty.fac_phoneNo = "030013231231";
            faculty.fac_Salary = 100000;
            

            WebSecurity.CreateUserAndAccount(username, password);
            Roles.AddUserToRole(username, "Faculty");
            faculty.user_ID = WebSecurity.GetUserId(username);

            sms.Faculties.Add(faculty);
            sms.SaveChanges();*/

            #endregion


            #region Student Registration

            /*string username = "laibahussain@gmail.com";
            string password = "123456";

            Student student = new Student();
            student.st_Name = "Laiba Hussain";
            student.st_Age = 15;
            student.st_FatherName = "Attique";
            student.st_Phone = "030013231231";
            student.cl_ID = 3;

            

            WebSecurity.CreateUserAndAccount(username, password);
            Roles.AddUserToRole(username, "Student");
            student.user_ID = WebSecurity.GetUserId(username);

            sms.Students.Add(student);
            sms.SaveChanges();


            // 2

            username = "usamakhan@gmail.com";
            password = "123456";

            student = new Student();
            student.st_Name = "Usama Khan";
            student.st_Age = 15;
            student.st_FatherName = "Bilal";
            student.st_Phone = "030013231231";
            student.cl_ID = 3;



            WebSecurity.CreateUserAndAccount(username, password);
            Roles.AddUserToRole(username, "Student");
            student.user_ID = WebSecurity.GetUserId(username);

            sms.Students.Add(student);
            sms.SaveChanges();

            // 3 

            username = "latifhussain@gmail.com";
            password = "123456";

            student = new Student();
            student.st_Name = "Latif Hussain";
            student.st_Age = 15;
            student.st_FatherName = "Syed Khan";
            student.st_Phone = "030013231231";
            student.cl_ID = 3;



            WebSecurity.CreateUserAndAccount(username, password);
            Roles.AddUserToRole(username, "Student");
            student.user_ID = WebSecurity.GetUserId(username);

            sms.Students.Add(student);
            sms.SaveChanges();

            // 4

            username = "zunairakhan@gmail.com";
            password = "123456";

             student = new Student();
            student.st_Name = "Zunaira Khan";
            student.st_Age = 15;
            student.st_FatherName = "Muneeb";
            student.st_Phone = "030013231231";
            student.cl_ID = 3;



            WebSecurity.CreateUserAndAccount(username, password);
            Roles.AddUserToRole(username, "Student");
            student.user_ID = WebSecurity.GetUserId(username);

            sms.Students.Add(student);
            sms.SaveChanges();


            // 5

            username = "waleedkhan@gmail.com";
            password = "123456";

            student = new Student();
            student.st_Name = "Waleed Khan";
            student.st_Age = 15;
            student.st_FatherName = "Abdullah";
            student.st_Phone = "030013231231";
            student.cl_ID = 3;



            WebSecurity.CreateUserAndAccount(username, password);
            Roles.AddUserToRole(username, "Student");
            student.user_ID = WebSecurity.GetUserId(username);

            sms.Students.Add(student);
            sms.SaveChanges();

            // 6

            username = "muntahakhan@gmail.com";
            password = "123456";

            student = new Student();
            student.st_Name = "Muntaha Khan";
            student.st_Age = 15;
            student.st_FatherName = "Mujeeb";
            student.st_Phone = "030013231231";
            student.cl_ID = 3;



            WebSecurity.CreateUserAndAccount(username, password);
            Roles.AddUserToRole(username, "Student");
            student.user_ID = WebSecurity.GetUserId(username);

            sms.Students.Add(student);
            sms.SaveChanges();

            // 7

            username = "areesha@gmail.com";
            password = "123456";

            student = new Student();
            student.st_Name = "Areesha Hussain";
            student.st_Age = 15;
            student.st_FatherName = "Hussain Latif";
            student.st_Phone = "030013231231";
            student.cl_ID = 3;



            WebSecurity.CreateUserAndAccount(username, password);
            Roles.AddUserToRole(username, "Student");
            student.user_ID = WebSecurity.GetUserId(username);

            sms.Students.Add(student);
            sms.SaveChanges();

            // 8 

            username = "zainkhan@gmail.com";
            password = "123456";

            student = new Student();
            student.st_Name = "Zain Khan";
            student.st_Age = 15;
            student.st_FatherName = "Shafiq Ahmed";
            student.st_Phone = "030013231231";
            student.cl_ID = 3;



            WebSecurity.CreateUserAndAccount(username, password);
            Roles.AddUserToRole(username, "Student");
            student.user_ID = WebSecurity.GetUserId(username);

            sms.Students.Add(student);
            sms.SaveChanges();

            //9

            username = "nimrakhan@gmail.com";
            password = "123456";

            student = new Student();
            student.st_Name = "Nimra Khan";
            student.st_Age = 15;
            student.st_FatherName = "Misbah Khan";
            student.st_Phone = "030013231231";
            student.cl_ID = 3;



            WebSecurity.CreateUserAndAccount(username, password);
            Roles.AddUserToRole(username, "Student");
            student.user_ID = WebSecurity.GetUserId(username);

            sms.Students.Add(student);
            sms.SaveChanges();

            //10

            username = "saqlainramzan@gmail.com";
            password = "123456";

            student = new Student();
            student.st_Name = "Saqlain Ramzan";
            student.st_Age = 15;
            student.st_FatherName = "Ramzan";
            student.st_Phone = "030013231231";
            student.cl_ID = 3;



            WebSecurity.CreateUserAndAccount(username, password);
            Roles.AddUserToRole(username, "Student");
            student.user_ID = WebSecurity.GetUserId(username);

            sms.Students.Add(student);
            sms.SaveChanges();
            */
            #endregion

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