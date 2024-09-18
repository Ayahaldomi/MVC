using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TASK17_09.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public int Age { get; set; }

        public StudentDetails Detail { get; set; }
    }
}