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
            //Get user.
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            //Create a new Dashboard ViewModel.
            DashboardViewModel DBVM = new DashboardViewModel();
            //Populate with user's Studio and Profile data.
            DBVM.ProfileData = await _context.Profiles
                .SingleOrDefaultAsync(m => m.ID == currentUser.ProfileID);
            DBVM.StudioData = await _context.StudioListings
                .SingleOrDefaultAsync(m => m.ID == currentUser.StudioID);
            //Populate user's booking information if it exists. 
            //Gather user incoming bookings. 
            List<Booking> UsersIncomingBookings = new List<Booking>();
            UsersIncomingBookings = (from p in _context.Booking
                                     where p.StudioUserID == currentUser.Id
                                     select new Booking
                                     {
                                         ID = p.ID,
                                         BookingStartTime = p.BookingStartTime,
                                         BookingEndTime = p.BookingEndTime,
                                         AmountofTimeBooked = p.AmountofTimeBooked,
                                         BookingUserID = p.BookingUserID,
                                         ReservationDate = p.ReservationDate,
                                         DateReservationWasMade = p.DateReservationWasMade,
                                         FinalCost = p.FinalCost,
                                         ConfirmationNumber = p.ConfirmationNumber,
                                         Status = p.Status,
                                         StudioUserID = p.StudioUserID
                                     }).ToList();

            //Gather user's outgoing bookings.
            List<Booking> UsersOutgoingBookings = new List<Booking>();
            UsersOutgoingBookings = (from p in _context.Booking
                                     where p.BookingUserID == currentUser.Id
                                     select new Booking
                                     {
                                         ID = p.ID,
                                         BookingStartTime = p.BookingStartTime,
                                         BookingEndTime = p.BookingEndTime,
                                         AmountofTimeBooked = p.AmountofTimeBooked,
                                         BookingUserID = p.BookingUserID,
                                         ReservationDate = p.ReservationDate,
                                         DateReservationWasMade = p.DateReservationWasMade,
                                         FinalCost = p.FinalCost,
                                         ConfirmationNumber = p.ConfirmationNumber,
                                         Status = p.Status,
                                         StudioUserID = p.StudioUserID,
                                     }).ToList();
            DBVM.IncomingBookings = UsersIncomingBookings;
            DBVM.OutgoingBookings = UsersOutgoingBookings;
            if (DBVM.IncomingBookings.Count != 0)
            {

                foreach (var item in DBVM.IncomingBookings)
                {
                    item.profileBooking = await _context.Profiles
                         .SingleOrDefaultAsync(m => m.User.Id.ToString() == item.BookingUserID);
                }
            }
            if (DBVM.OutgoingBookings.Count != 0)
            {

                foreach (var item in DBVM.OutgoingBookings)
                {
                    item.studioBooked = await _context.StudioListings
                         .SingleOrDefaultAsync(m => m.User.Id.ToString() == item.StudioUserID);
                }
            }
            //Return the view passing throught the view model. 
            return View(DBVM);
        }
    }
}
