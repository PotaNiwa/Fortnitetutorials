using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Fortnitetutorials.Models
{
    public class MixupContext : DbContext
    {                         
        public DbSet<Guide> Guide { get; set; }
        public DbSet<category> Category { get; set; }
    }
}