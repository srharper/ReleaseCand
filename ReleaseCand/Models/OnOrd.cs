using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReleaseCand.Models
{
    public class OnOrd
    {
        public int OnOrderID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool CheeseBurger { get; set; }
        public bool Lasagna { get; set; }
        public bool TiriMisu { get; set; }
        public bool CheeseCake { get; set; }
        public bool FrenchFries { get; set; }
        public bool Pepsi { get; set; }
        public bool Sprite { get; set; }
        public bool Water { get; set; }
        public string BillAddress { get; set; }
        public string BillCity { get; set; }
        public string BillState { get; set; }
        public string BillZip { get; set; }
        public string CreditCardNum { get; set; }
        public string CCV { get; set; }
        public DateTime ExpDate { get; set; }

    }
}
