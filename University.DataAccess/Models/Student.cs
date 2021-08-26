using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess.Data;

namespace University.DataAccess.Models
{
   public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }

        public virtual int? GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }

    }
}
