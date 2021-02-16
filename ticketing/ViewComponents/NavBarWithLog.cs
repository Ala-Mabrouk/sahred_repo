using AppFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticketing.ViewComponents
{
    public class NavBarWithLog:ViewComponent
    {
        public IViewComponentResult Invoke()

        {

                   SupportUserFeature objSupportUserFeature = new SupportUserFeature();
                   var res = objSupportUserFeature.getUser((int)HttpContext.Session.GetInt32("userID"));

                ViewBag.userLoged = res.Name+" "+res.LastName;

            return View();
        }
    }
}
