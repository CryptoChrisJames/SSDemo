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
        public DateTime DateOfBooking { get; set; }

        public DateTime DateReservationWasMade { get; set; } 
        public int AmountofTimeBooked { get; set; }
        public int FinalCost { get; set; }
        public int ConfirmationNumber { get; set; }
        public Studio StudioBooked { get; set; }
        public Profile ProfileMakingReservation { get; set; }
        public StatusType Status { get; set; }

        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            var selectList = new List<SelectListItem>();

            // Get all values of the BookingTimes enum
            var enumValues = Enum.GetValues(typeof(BookingTimes)) as BookingTimes[];
            if (enumValues == null)
                return null;

            foreach (var enumValue in enumValues)
            {
                // Create a new SelectListItem element and set its 
                // Value and Text to the enum value and description.
                selectList.Add(new SelectListItem
                {
                    Value = enumValue.ToString(),
                    // GetBookingTimesName just returns the Display.Name value
                    // of the enum - check out the next chapter for the code of this function.
                    Text = GetBookingTimesName(enumValue)
                });
            }

            return selectList;
        }

        public string GetBookingTimesName(BookingTimes value)
        {
            // Get the MemberInfo object for supplied enum value
            var memberInfo = value.GetType().GetMember(value.ToString());
            if (memberInfo.Length != 1)
                return null;

            // Get DisplayAttibute on the supplied enum value
            var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false)
                                   as DisplayAttribute[];
            if (displayAttribute == null || displayAttribute.Length != 1)
                return null;

            return displayAttribute[0].Name;
        }

    }
}
