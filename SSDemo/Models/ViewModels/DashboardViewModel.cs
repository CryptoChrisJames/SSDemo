using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSImplementation.Models.ViewModels
{
    public class DashboardViewModel
    {
        public Profile ProfileData { get; set; }
        public Studio StudioData { get; set; }
        public IList<Booking> IncomingBookings { get; set; }
        public IList<Booking> OutgoingBookings { get; set; }
     }
}