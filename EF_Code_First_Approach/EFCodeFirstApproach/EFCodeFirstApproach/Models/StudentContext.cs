using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFCodeFirstApproach.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Students> students { get; set; } 
    }
}