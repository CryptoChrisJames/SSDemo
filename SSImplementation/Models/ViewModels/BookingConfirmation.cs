using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSImplementation.Models.ViewModels
{
    public class BookingConfirmation
    {
        public Booking newBooking { get; set; }
        public ApplicationUser currentUser { get; set; }
        public ApplicationUser userBeingBooked { get; set; }
    }
}
