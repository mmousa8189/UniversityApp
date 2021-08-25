using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess.Data;

namespace University.DataAccess.Models
{
   public class Course : BaseEntity
    {
        public string CourseName { get; set; }
        public string Description { get; set; }
        public IList<StudentCourse> StudentCourses { get; set; }

    }
}
