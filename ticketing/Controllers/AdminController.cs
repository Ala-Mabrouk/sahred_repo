using AppFeatures;
using Entity_DAL.DAL;
using Entity_DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace ticketing.Controllers
{
    public class AdminController : Controller
    {

        //global variable of SupportUserFeature
       private SupportUserFeature objSupportUserFeature = new SupportUserFeature();


        //this will open a login-Admin page
        public ActionResult Index()
        {
            return RedirectToAction("DashBoardAdmin", "Admin");
            //if (HttpContext.Session.GetString("userRole") != null)
            //{
            //   return RedirectToAction("DashBoardAdmin", "Admin");
            //}
            //else
            //{

            //return View();
            //}

        }


        //verifing the admin login in 
        //[HttpPost]
        //public IActionResult Log_in(SupportUser user)
        //{
                        
        //    string test = objSupportUserFeature.Log_in(user.Email, user.Password);



        //    //Creation of a session when a sucsseful Admin log come in and moving to "DashBoardAdmin" view .
        //    if (test != null)
        //    {
        //        string role = test.Substring(0,test.IndexOf('?'));
        //        int id = Int32.Parse(test.Substring(test.IndexOf('?') + 1, test.Length- test.IndexOf('?')-1));
        //        if (role == "admin")
        //        {

        //            HttpContext.Session.SetString("userRole", role);
        //            HttpContext.Session.SetInt32("userID", id);
        //            return RedirectToAction("DashBoardAdmin", "Admin");
        //        }
        //    }
        //    ViewBag.loged = "Check your email and password !";
        //    return RedirectToAction("Index", "Admin");
        //}

        //opens the admin page
        public IActionResult DashBoardAdmin()

        {
            if (HttpContext.Session.GetString("userRole") ==null || HttpContext.Session.GetString("userRole") != "admin")
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
                if (objSupportUserFeature.CreateNewUser(objSupport).Result)
                {
                    return RedirectToAction("ShowUsers", "Admin");
                }

            }
            return View();
        }

    }
}
