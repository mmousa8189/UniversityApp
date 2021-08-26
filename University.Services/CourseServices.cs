using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess.Models;
using University.DataAccess.Repository;
using University.Services.DTOs;

namespace University.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly IRepository _repository;
        public CourseServices(IRepository repository)
        {
            _repository = repository;
        }
        public List<Course> GetAll()
        {
            return _repository.GetAll<Course>().ToList();
        }

        public Course GetCourse(int courseId)
        {
            return _repository.Get<Course>(courseId);
        }
        public CourseDTO GetCourseDTO(int courseId)
        {
            var course = _repository.Get<Course>(courseId);
            CourseDTO dto = new CourseDTO()
            {
                Id = course.Id,
                CourseName = course.CourseName,
                Description = course.Description
            };
            return dto;
        }
        public List<Course> GetCoursesByStudentId(int studentId)
        {
            return _repository.Get<Student>(studentId).StudentCourses.Select(c => c.Course).ToList();
        }

        public void AddCourse(CourseDTO courseDto)
        {
            var course = new Course()
            {
                CourseName = courseDto.CourseName,
                Description = courseDto.Description
            };
            _repository.Insert(course);
        }

        public void UpdateCourse(CourseDTO courseDto)
        {
            //get first 
            var courseFromDb = GetCourse(courseDto.Id);
            courseFromDb.CourseName = courseDto.CourseName;
            courseFromDb.Description = courseDto.Description;
            _repository.Update(courseFromDb);
        }

        public void DeleteCourse(int id)
        {
            var objFromDb = GetCourse(id);
            _repository.Delete(objFromDb);
        }
    }
}
