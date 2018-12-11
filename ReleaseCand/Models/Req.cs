using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReleaseCand.Models
{
    public class Req
    {
        public int ReqID { get; set; }
        public DateTime Date { get; set; }
        public Meal Meal { get; set; }
        public CreditIn CreditIn { get; set; }
        public PerInfo PerInfo { get; set; }
    }
}
