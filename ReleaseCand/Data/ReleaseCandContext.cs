using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReleaseCand.Models;
using ReleaseCand.ViewModels;

namespace ReleaseCand.Models
{
    public class ReleaseCandContext : DbContext
    {
        public ReleaseCandContext (DbContextOptions<ReleaseCandContext> options)
            : base(options)
        {
        }

        public DbSet<ReleaseCand.Models.OnOrd> OnOrd { get; set; }

        public DbSet<ReleaseCand.Models.Reservation> Reservation { get; set; }

        public DbSet<ReleaseCand.Models.Customer> Customer { get; set; }

        public DbSet<ReleaseCand.ViewModels.CustomerReportViewModel> CustomerReportViewModel { get; set; }
    }
}
