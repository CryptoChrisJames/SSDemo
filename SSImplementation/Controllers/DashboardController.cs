using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSImplementation.Data;
using Microsoft.AspNetCore.Identity;
using SSImplementation.Models;
using Microsoft.EntityFrameworkCore;
using SSImplementation.Models.ViewModels;

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
            DashboardViewModel DBVM = new DashboardViewModel();
            DBVM.ProfileData = await _context.Profiles
                .SingleOrDefaultAsync(m => m.ID == currentUser.ProfileID);
            DBVM.StudioData = await _context.StudioListings
                .SingleOrDefaultAsync(m => m.ID == currentUser.StudioID);
            return View(DBVM);
        }
    }
}
