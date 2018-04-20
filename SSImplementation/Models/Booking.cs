using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SSImplementation.Models
{
    public enum BookingTimes
    {
         
        _8AM = 800,
        _9AM = 900,
        _10AM = 1000,
        _11AM = 1100,
        _12PM = 1200,
        _1PM = 1300,
        _2PM = 1400,
        _3PM = 1500,
        _4PM = 1600,
        _5PM = 1700,
        _6PM = 1800,
        _7PM = 1900,
        _8PM = 2000,


    }
    public enum StatusType
    {
        Accepted,
        Declined,
        Pending,
        Error,
        Reviewing,
        Outstanding
    }



    
    public class Booking
    {

        public int ID { get; set; }
        public int BookingStartTime { get; set; }
        public int BookingEndTime { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ReservationDate { get; set; }

        public DateTime DateReservationWasMade { get; set; } 
        public int AmountofTimeBooked { get; set; }
        public int FinalCost { get; set; }
        public string ConfirmationNumber { get; set; }
        public string StudioUserID { get; set; }
        public string BookingUserID { get; set; }
        public StatusType Status { get; set; }
    }
}
