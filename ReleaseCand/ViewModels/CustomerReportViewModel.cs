using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ReleaseCand.ViewModels
{
    public class CustomerReportViewModel
    {

        public int CustomerReportViewModelID { get; set; }

        [DisplayName("Last Name: ")]
        public string LastName { get; set; }

        [DisplayName("First Name: ")]
        public string FirstName { get; set; }

        public DateTime CustomerDate { get; set; }

        public int NumOfGuests { get; set; }

    }
}
