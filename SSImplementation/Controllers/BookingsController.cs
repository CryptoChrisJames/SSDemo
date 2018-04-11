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
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public BookingsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Booking/ConfirmBooking
        public async Task<IActionResult> ConfirmBooking(StudioListingAndBookingViewModel SLAB)
        {
            DateTime CurrentTime = new DateTime();
            CurrentTime = DateTime.Now;
            SLAB.BookingTransaction.ProfileMakingReservation =
                await _context.Profiles.SingleOrDefaultAsync(m => m.ID == SLAB.UserBooking.ID);
            SLAB.BookingTransaction.StudioBooked = 
                await _context.StudioListings.SingleOrDefaultAsync(m => m.ID == SLAB.StudioBeingBooked.ID);
            SLAB.BookingTransaction.DateReservationWasMade = CurrentTime;
            SLAB.BookingTransaction.Status = StatusType.Pending;


            return View(SLAB);
        }
    }
}