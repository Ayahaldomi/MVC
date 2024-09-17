using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace task17_09.Models
{
    public class Assignment
    {
        [Key]
        public int ID { get; set; }


        public string AsignmentName { get; set; }

        public DateTime? date { get; set; } = DateTime.Now;
    }
}