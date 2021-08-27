using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Services.DTOs
{
   public class CourseStudentViewDTO
    {
        public string CourseName { get; set; }
        public string Description { get; set; }
        public List<string> StudentsName { get; set; }
    }
}
