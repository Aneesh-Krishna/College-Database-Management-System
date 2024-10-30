using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CollegeDatabaseManagementSystem.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        [DataType(DataType.Date)]   
        public DateTime Date { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
