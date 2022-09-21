using Microsoft.AspNetCore.Identity;
using SSImplementation.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSImplementation.Data
{
    public class ApplicationRole : IdentityRole<Guid>
    {

        [ForeignKey("Profile")]
        public int ProfileID { get; set; }
        public Profile Profile { get; set; }

        [ForeignKey("Studio")]
        public int StudioID { get; set; }
        public Studio Studio { get; set; }
    }
}