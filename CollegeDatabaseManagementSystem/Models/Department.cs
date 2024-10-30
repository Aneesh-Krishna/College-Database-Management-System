using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeDatabaseManagementSystem.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
        
        public string HeadOfDepartment { get; set; }

        public ICollection<Course>? Courses { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Faculty>? Faculties { get; set; }
    }
}
