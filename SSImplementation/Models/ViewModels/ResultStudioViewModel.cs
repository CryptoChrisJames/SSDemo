using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSImplementation.Models.ViewModels
{
    public class ResultStudioViewModel
    {
        public int ID { get; set; }
        public string StudioName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Studio.USStates State { get; set; }
        public int StudioPrice { get; set; }
        public string StudioDescription { get; set; }
        public string StudioPicture { get; set; }
        public string UserID { get; set; }

    }
}
