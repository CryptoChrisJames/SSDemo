using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSImplementation.Data;
using SSImplementation.Models;
using SSImplementation.Models.ViewModels;

namespace SSImplementation.Controllers
{
    public class StudiosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _environment;

        public StudiosController(ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager, IHostingEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;
        }

        // GET: Studios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            var SelectedStudio = await _context.StudioListings
                .SingleOrDefaultAsync(m => m.ID == id);
            SelectedStudio.User = await _context.Users
                .SingleOrDefaultAsync(m => m.StudioID == SelectedStudio.ID);
            SelectedStudio.User.Profile = await _context.Profiles
                .SingleOrDefaultAsync(m => m.User.Id == SelectedStudio.User.Id);
            StudioListingAndBookingViewModel SLAB = new StudioListingAndBookingViewModel();
            SLAB.StudioBeingBooked = SelectedStudio.User;
            SLAB.UserBooking = currentUser;
            SLAB.BookingTransaction = new Booking();
            SLAB.BookingTransaction.StudioUserID = SLAB.StudioBeingBooked.Id.ToString();
            SLAB.BookingTransaction.BookingUserID = SLAB.UserBooking.Id.ToString();
            return View(SLAB);
        }

        
        // GET: Studios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            var studio = await _context.StudioListings
                .SingleOrDefaultAsync(m => m.ID == currentUser.StudioID);
            return View(studio);
        }

        // POST: Studios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Type,isAvailable,Address," +
            "ListingDescription,State,City,numberOfRooms,pictureOfRoom,StudioName,PricePerHour," +
            "CancellationFee,StudioRules,StudioPictureFile")] Studio studio, IFormFile StudioPictureFile)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {

                if (StudioPictureFile!= null)
                {
                    string uploadpath = Path.Combine(_environment.WebRootPath, "StudioPictures");
                    Directory.CreateDirectory(Path.Combine(uploadpath, currentUser.Id.ToString()));
                    string filename = Path.GetFileName(StudioPictureFile.FileName);
                    using (FileStream fs = new FileStream(Path.Combine(uploadpath, currentUser.Id.ToString(), filename), FileMode.Create))
                    {
                        await StudioPictureFile.CopyToAsync(fs);
                    }
                    studio.pictureOfRoom = filename;
                }
                _context.Update(studio);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Dashboard");
            }
            return View(studio);
        }
        
    }
}
