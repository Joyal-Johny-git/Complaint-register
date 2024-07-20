using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace task.Models
{
    [Table("Assignments")]
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public int ComplaintID { get; set; }
        public int TechnicianID { get; set; }
        public string Status { get; set; }
        public string WorkDone { get; set; }
        public string MaterialsUsed { get; set; }
        public decimal Cost { get; set; }
    }

}