using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReleaseCand.Models
{
    public class ReleaseCandContext : DbContext
    {
        public ReleaseCandContext (DbContextOptions<ReleaseCandContext> options)
            : base(options)
        {
        }

        public DbSet<ReleaseCand.Models.OnOrd> OnOrd { get; set; }
    }
}
