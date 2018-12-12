using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ReleaseCand.Models
{
    public class Special
    {
        [DisplayName("Number of Guests: ")]
        public int NumOfGuests { get; set; }

        [DisplayName("Please Indicate the Reservation Type (Birthday, Corporate, or Regular Reservation):")]
        public string Reasons { get; set; }

        [DisplayName("If any other reasons, please indicate in the box:")]
        public string Other { get; set; }
    }
}
