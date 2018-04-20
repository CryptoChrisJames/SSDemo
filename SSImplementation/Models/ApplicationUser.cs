using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSImplementation.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Profile")]
        public int ProfileID { get; set; }
        public Profile Profile { get; set; }
        [ForeignKey("Studio")]
        public int StudioID { get; set; }
        public Studio Studio { get; set; }
        [ForeignKey("Booking")]
        public int BookingID { get; set; }
        public Booking Incoming { get; set; }
    }
}
