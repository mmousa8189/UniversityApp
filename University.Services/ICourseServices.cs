using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess.Models;
using University.Services.DTOs;

namespace University.Services
{
   public interface ICourseServices
    {
        public void AddCourse(CourseDTO courseDto);
        public void DeleteCourse(int id);
        public List<Course> GetAll();
        public Course GetCourse(int courseId);
        public CourseDTO GetCourseDTO(int courseId);
        public List<Course> GetCoursesByStudentId(int studentId);
        public void UpdateCourse(CourseDTO courseDto);
    }
}
