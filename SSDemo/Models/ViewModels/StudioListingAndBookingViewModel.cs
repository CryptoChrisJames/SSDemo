using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSImplementation.Models.ViewModels
{
    public class StudioListingAndBookingViewModel
    {
        public ApplicationUser StudioBeingBooked { get; set; }
        public ApplicationUser UserBooking { get; set; }
        public Booking BookingTransaction { get; set; }
    }
}
