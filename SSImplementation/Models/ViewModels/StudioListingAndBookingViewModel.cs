using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSImplementation.Models.ViewModels
{
    public class StudioListingAndBookingViewModel
    {
        public Studio StudioBeingBooked { get; set; }
        public Profile UserBooking { get; set; }
        public Booking BookingTransaction { get; set; }
    }
}
