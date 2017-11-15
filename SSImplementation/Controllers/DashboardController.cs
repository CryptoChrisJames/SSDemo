using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SSImplementation.Controllers
{
    public class DashboardController : Controller
    {
        // GET: /Dashboard/Index
        public IActionResult Index()
        {
            return View(); 
        }
    }
}
