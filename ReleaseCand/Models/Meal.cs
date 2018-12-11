using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReleaseCand.Models
{
    public class Meal
    {
        public int MealID { get; set; }
        [Display(Name = "Cheese Burger")]
        public bool CheeseBurger { get; set; }
        public bool lasagna { get; set; }
        public bool TiraMisu { get; set; }
        public bool CheeseCake { get; set; }
        [Display(Name = "French Fries")]
        public bool Fries { get; set; }
        public bool Pepsi { get; set; }
        public bool Sprite { get; set; }
        public bool Water { get; set; }
    }
}
