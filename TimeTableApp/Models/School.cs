﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TimeTableApp.Models
{
    public class School
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}