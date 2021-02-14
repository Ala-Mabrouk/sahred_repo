using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticketing.Controllers
{
    public class Con_SupportUsers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
