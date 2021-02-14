using AppFeatures;
using Entity_DAL.DAL;
using Entity_DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace ticketing.Controllers
{
    public class AdminController : Controller
    {

        //this will open a login-Admin page
        public ActionResult Index()
        {
            return View();
        }


        //verifing the admin login in 
        [HttpPost]
        public IActionResult Log_in(SupportUser user)
        {
            SupportUserFeature objSupportUserFeature = new SupportUserFeature();
            var test = objSupportUserFeature.Log_in(user.Email, user.Password);

            //Creation of a session when a sucsseful Admin log come in and moving to "DashBoardAdmin" view .
            if (test != null && test.RoleId == 1)
            {
                HttpContext.Session.SetString("userRole", test.RoleId + "");
                HttpContext.Session.SetInt32("userID", test.UserID);
                return RedirectToAction("DashBoardAdmin", "Admin");

            }
            ViewBag.loged = "Check your email and password !";
            return RedirectToAction("Index", "Admin");
        }

        //opens the admin page
        public IActionResult DashBoardAdmin()

        {
            if (HttpContext.Session.GetString("userRole") == null)
            {
                return RedirectToAction("Index", "Admin");
            }

            int a = (int)HttpContext.Session.GetInt32("userID");
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                var res = context.SupportUsers.SingleOrDefault(u => u.UserID == a);
                ViewBag.loged_Name = res.Name + " " + res.LastName;
                return View();
            }

        }

        public ActionResult ShowUsers()
        {
            SupportUserFeature objSupportUserFeature = new SupportUserFeature();
            var usersList = objSupportUserFeature.ListUsers();
            ViewBag.usersList = usersList;

            return View();


        }
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(SupportUser objSupport)
        {
            if (ModelState.IsValid)
            {
                SupportUserFeature objSupportUserFeature = new SupportUserFeature();

                if (objSupportUserFeature.CreateNewUser(objSupport).Result)
                {
                    return RedirectToAction("ShowUsers", "Admin");
                }

            }
            return View();
        }

    }
}
