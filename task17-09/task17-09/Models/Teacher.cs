using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace task17_09.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        
        public string TeacherName { get; set; }
       
        public int Age { get; set; }
    }
}