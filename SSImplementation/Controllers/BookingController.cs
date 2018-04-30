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
using SSImplementation.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace SSImplementation.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public BookingController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        [AutoValidateAntiforgeryToken]
        // POST: Booking/ConfirmBooking
        public async Task<IActionResult> ConfirmBooking(StudioListingAndBookingViewModel SLAB)
        {
            BookingConfirmation newBookingConfirmation = new BookingConfirmation();
            newBookingConfirmation.newBooking = SLAB.BookingTransaction;

            DateTime CurrentTime = new DateTime();
            CurrentTime = DateTime.Now;
            newBookingConfirmation.newBooking.DateReservationWasMade = CurrentTime;
            newBookingConfirmation.newBooking.Status = StatusType.Pending;

            newBookingConfirmation.currentUser = await _userManager.GetUserAsync(User);
            newBookingConfirmation.userBeingBooked = await _context.Users
                .SingleOrDefaultAsync(x => x.Id == newBookingConfirmation.newBooking.StudioUserID);
            newBookingConfirmation.userBeingBooked.Studio = await _context.StudioListings
                .SingleOrDefaultAsync(x => x.User.Id == newBookingConfirmation.newBooking.StudioUserID);
            return View(newBookingConfirmation);
        }


        [ValidateAntiForgeryToken]
        //GET: Booking/ProcessBooking
        public async Task<IActionResult> ProcessBooking(Booking newBooking)
        {
            newBooking.ConfirmationNumber = BookingConfirmation();
            _context.Add(newBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(BookingController.BookingSuccessful), "Booking", newBooking);
        }

        public async Task<IActionResult> BookingSuccessful(Booking confirmedBooking)
        {
            return View(confirmedBooking);
        }

        private string BookingConfirmation()
        {

            Random random = new Random();
            string cnum = "";
            int i;
            for (i = 1; i < 11; i++)
            {
                cnum += random.Next(0, 9).ToString();
            }
            return cnum;
        }
    }
}