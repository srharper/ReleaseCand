using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReleaseCand.Models
{
    public class Customer
    {

        public int CustomerID { get; set; }

        public DateTime CustomerDate { get; set; }

        public int NumOfGuests { get; set; }

        public Reservation Reservation { get; set; }
    }
}
