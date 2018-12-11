using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReleaseCand.Models
{
    public class PerInfo
    {
        public int PerInfoID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        [StringLength(14)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
    }
}
