using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReleaseCand.Models
{
    public class CreditIn
    {
        public int CreditInID { get; set; }
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
