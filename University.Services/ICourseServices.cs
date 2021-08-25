using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess.Models;

namespace University.Services
{
   public interface ICourseServices
    {
        void AddCourse(Course course);
        public List<Course> GetAll();
        public Course GetCourse(int courseId);
        public List<Course> GetCoursesByStudentId(int studentId);
    }
}
