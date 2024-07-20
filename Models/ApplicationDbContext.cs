using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace task.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
    }

}