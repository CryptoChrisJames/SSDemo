using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSImplementation.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using SSImplementation.Data;
using SSImplementation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace SSImplementation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult SearchResults(SearchStudioViewModel SSVM)
        {
            List<ResultStudioViewModel> results = new List<ResultStudioViewModel>();
            results = (from p in _context.StudioListings
                      where p.City == SSVM.City
                      || p.State == SSVM.State
                      || p.ZipCode == SSVM.ZipCode
                      select new ResultStudioViewModel
                      {
                          ID = p.ID,
                          StudioName = p.StudioName,
                          Address = p.Address,
                          City = p.City,
                          State = p.State,
                          StudioPrice = p.PricePerHour,
                          StudioPicture = p.pictureOfRoom,
                          StudioDescription = p.ListingDescription,
                          UserID = p.User.Id,
                          
                      }
                      ).ToList();
                      
            return View("SearchResults", results);
        }
    }
}
