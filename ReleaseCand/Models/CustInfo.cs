using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ReleaseCand.Models
{
    public class CustInfo
    {
        [DisplayName("Last Name: ")]
        public string LastName { get; set; }

        [DisplayName("First Name: ")]
        public string FirstName { get; set; }

        [DisplayName("Email: ")]
        public string Email { get; set; }

        [DisplayName("Phone Number: ")]
        public int PhoneNumber { get; set; }
    }
}
