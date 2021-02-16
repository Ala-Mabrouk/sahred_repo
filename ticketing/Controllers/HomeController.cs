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
            SupportUserFeature objSupportUserFeature = new SupportUserFeature();
            string test = objSupportUserFeature.Log_in(user.Email, user.Password);

            if (test != null)
            {
                //getting role and userId from test='ROLE?ID'

                string role = test.Substring(0,test.IndexOf('?'));
                int id = Int32.Parse(test.Substring(test.IndexOf('?') + 1, test.Length- test.IndexOf('?')-1));

                if (role == "client")
                {
                    HttpContext.Session.SetString("userRole", role);
                    HttpContext.Session.SetInt32("userID", id);
                    ViewBag.log = "true";
                }
            }
         
            return RedirectToAction("Index", "Home");
        }


    }
}
