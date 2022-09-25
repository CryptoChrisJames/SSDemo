using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSImplementation.Models.ViewModels
{
    public class SearchStudioViewModel
    {
        public string City { get; set; }
        public Studio.USStates State { get; set; }
        public int ZipCode { get; set; }
    }
}
