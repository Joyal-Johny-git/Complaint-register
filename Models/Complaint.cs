using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace task.Models
{
    [Table("Complaints")]
    public class Complaint
    {
        public int ComplaintID { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string WorkDetails { get; set; }
        public string WorkCategory { get; set; }
        public string Status { get; set; } = "New";
    }
}