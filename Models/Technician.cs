using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace task.Models
{
    [Table("Technicians")]
    public class Technician
    {
        public int TechnicianID { get; set; }
        public string Name { get; set; }
        public string WorkCategory { get; set; }
    }
}