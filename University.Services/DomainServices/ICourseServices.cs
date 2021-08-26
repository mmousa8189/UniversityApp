using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess.Models;
using University.Services.DTOs;

namespace University.Services.DomainServices
{
   public interface ICourseServices
    {
        public void AddCourse(CourseDTO courseDto);
        void AssgineStudentsToCourse(AssignStudentsDTO assignStudentsDTO);
        public void DeleteCourse(int id);
        public List<Course> GetAll();
        AssignStudentsDTO GetAllStudentWithCourseToAssign(int courseId);
        public Course GetCourse(int courseId);
        public CourseDTO GetCourseDTO(int courseId);
        public List<Course> GetCoursesByStudentId(int studentId);
        public void UpdateCourse(CourseDTO courseDto);
    }
}
