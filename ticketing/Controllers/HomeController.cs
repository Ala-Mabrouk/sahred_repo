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
            //need to check the session when we load the index view
          return View();
        }

        public IActionResult Log_in()
          
        {
            //need to be re-implemented 
            return View();
        }
 

        //[HttpPost]
        //public   IActionResult Log_in(SupportUser user)
        //{
        //    SupportUserFeature objSupportUserFeature = new SupportUserFeature();
        //    var test = objSupportUserFeature.Log_in(user.Email,user.Password);

        //    //Creation of a session when a sucsseful log come in and moving to "done" view .
        //    if (test!=null)
        //    {                System.Diagnostics.Debug.WriteLine("userRole: "+ user.RoleId + "");
        //        System.Diagnostics.Debug.WriteLine("userID: "+user.Name);
        //        HttpContext.Session.SetString("userRole",user.RoleId+"");
        //        HttpContext.Session.SetInt32("userID", user.UserID);



        //        return RedirectToAction("done", "home");
        //    }

        //    return View();
            
        //}

 
 
    }
}
