using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ReleaseCand.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }

        [DisplayName("Last Name: ")]
        public string LastName { get; set; }

        [DisplayName("First Name: ")]
        public string FirstName { get; set; }

        [DisplayName("Email: ")]
        public string Email { get; set; }

        [DisplayName("Phone Number: ")]
        public int PhoneNumber { get; set; }

        [DisplayName("Number of Guests: ")]
        public int NumOfGuests { get; set; }

        [DisplayName("Please Indicate the Reservation Type (Birthday, Corporate, or Regular Reservation):")]
        public string Reasons { get; set; }

        [DisplayName("If any other reasons, please indicate in the box:")]
        public string Other { get; set; }

        [DisplayName("Please indicate a special request for a reservation room: ")]
        public string SpecialRequests { get; set; }
    }
}
