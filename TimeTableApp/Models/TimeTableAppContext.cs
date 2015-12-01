using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TimeTableApp.Models
{
    public class TimeTableAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TimeTableAppContext() : base("name=TimeTableAppContext")
        {
        }

        public System.Data.Entity.DbSet<TimeTableApp.Models.Classroom> Classrooms { get; set; }

        public System.Data.Entity.DbSet<TimeTableApp.Models.School> Schools { get; set; }

        public System.Data.Entity.DbSet<TimeTableApp.Models.SchoolClassroom> SchoolClassrooms { get; set; }

        public System.Data.Entity.DbSet<TimeTableApp.Models.Subject> Subjects { get; set; }

        public System.Data.Entity.DbSet<TimeTableApp.Models.Teacher> Teachers { get; set; }

        public System.Data.Entity.DbSet<TimeTableApp.Models.TimeTableEntry> TimeTableEntries { get; set; }
    
    }
}
