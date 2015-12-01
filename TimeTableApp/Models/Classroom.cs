using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TimeTableApp.Models
{
    public class Classroom
    {
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
    }
}