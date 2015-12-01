using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTableApp.Models
{
    public class TimeTableEntry
    {
        //The class contains a fields for Foreign Keys and Navigation Properties
        public int Id { get; set; }
        public int SchoolId { get; set; }        
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public DayOfWeek Day { get; set; }


        public enum DayOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
    }
}