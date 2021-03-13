using AppFeatures;
using Entity_DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticketing.Controllers
{
    //this controller and the view are to test the features and classes

    public class HomeController : Controller
    {
      private  SupportUserFeature objSupportUserFeature = new SupportUserFeature();
        public IActionResult Index()
        {
            // check the session when we load the index view

            if (HttpContext.Session.GetString("userRole") != null)
            {
                ViewBag.Log = "true";
            }
            return View();
        }

        [HttpPost]
        public IActionResult Log_in(SupportUser user)
          
        {
         string test = objSupportUserFeature.Log_in(user.Email, user.Password);
            string role = "";
            if (test != null)
            {
                //getting role and userId from test='ROLE?ID'

                  role = test.Substring(0,test.IndexOf('?'));
                int id = Int32.Parse(test.Substring(test.IndexOf('?') + 1, test.Length- test.IndexOf('?')-1));
 
                    HttpContext.Session.SetString("userRole", role);
                    HttpContext.Session.SetInt32("userID", id);
                    ViewBag.log = "true";

                switch (role)
                {
                    case "client": return RedirectToAction("Index", "Home");
                    case "admin": return RedirectToAction("DashBoardAdmin", "Admin");
                    case "simpleTech": return RedirectToAction("Index", "SupportUsers");
                }
            }
         
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sign_Up(SupportUser user)
        {
            //making role field as Client
            if (ModelState.IsValid)
            {
                user.RoleId = 2;
                if (objSupportUserFeature.CreateNewUser(user).Result)
                {
                    HttpContext.Session.SetString("userRole", user.RoleId + "");
                    HttpContext.Session.SetInt32("userID", user.UserID);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    return RedirectToAction("Erreur", "Home");
                }

            } return View(user);
        }

        public ActionResult Erreur()
        {
            return View();
        }

    }
}
