using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TASK17_09.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TeacherName { get; set; }
        [Required]
        public int Age { get; set; }
        public int Ages { get; set; }

        public virtual ICollection<Course> Courses { get; set; }


    }
}