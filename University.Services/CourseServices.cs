using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess.Models;
using University.DataAccess.Repository;

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
            throw new NotImplementedException();
        }

        public List<Course> GetCoursesByStudentId(int studentId)
        {
            return _repository.Get<Student>(studentId).StudentCourses.Select(c=> c.Course).ToList();
        }

        public void AddCourse(Course course)
        {
            _repository.Insert(course);
        }
    }
}
