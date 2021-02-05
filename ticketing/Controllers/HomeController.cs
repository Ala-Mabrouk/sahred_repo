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
        public IActionResult Index()
        {
            //check if there is an open sesion in the app 
            if (HttpContext.Session.GetString("userRole") != null)
            {
                return RedirectToAction("done", "home");
            }
            else
                return View();
        }

        public IActionResult Log_in()
          
        {
            if (HttpContext.Session.GetString("userRole") != null)
            {
                return RedirectToAction("done", "home");
            }else
            return View();
        }
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public   IActionResult Log_in(SupportUser user)
        {
            SupportUserFeature objSupportUserFeature = new SupportUserFeature();
            var test = objSupportUserFeature.Log_in(user.Email,user.Password);

            //Creation of a session when a sucsseful log come in and moving to "done" view .
            if (test==true)
            {
                HttpContext.Session.SetString("userRole",user.Role+":"+user.Level);
                HttpContext.Session.SetInt32("userID", user.UserID);
                return RedirectToAction("done", "home");
            }

            return View();
            
        }

        public IActionResult done()
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
                    ViewBag.message = "done ! thank you";
                }
               
            } return View();
        }
    }
}
