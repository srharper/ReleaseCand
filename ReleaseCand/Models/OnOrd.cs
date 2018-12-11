using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReleaseCand.Models
{
    public class OnOrd
    {
        public int OnOrdID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        [StringLength(14)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Cheese Burger")]
        public bool CheeseBurger { get; set; }
        public bool Lasagna { get; set; }
        public bool TiraMisu { get; set; }
        public bool CheeseCake { get; set; }
        [Display(Name = "French Fries")]
        public bool FrenchFries { get; set; }
        public bool Pepsi { get; set; }
        public bool Sprite { get; set; }
        public bool Water { get; set; }
        public string BillAddress { get; set; }
        public string BillCity { get; set; }
        public string BillState { get; set; }
        [StringLength(5)]
        public string BillZip { get; set; }
        public string CreditCardNum { get; set; }
        [StringLength(3)]
        public string CCV { get; set; }
        public DateTime ExpDate { get; set; }

    }
}
