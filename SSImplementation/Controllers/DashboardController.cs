using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSImplementation.Data;
using Microsoft.AspNetCore.Identity;
using SSImplementation.Models;
using Microsoft.EntityFrameworkCore;

namespace SSImplementation.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public DashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /Dashboard/Index
        public async Task<IActionResult> Index()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            var profile = await _context.Profiles.SingleOrDefaultAsync(m => m.ID == currentUser.ProfileID);
            return View(profile); 
        }
    }
}
