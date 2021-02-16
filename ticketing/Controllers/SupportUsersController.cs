using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticketing.Controllers
{
    public class SupportUsersController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("userRole") != null)
            {
                ViewBag.Log = "true";
            }
            return View();
        }
    }
}
