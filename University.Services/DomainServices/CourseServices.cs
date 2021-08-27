using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using University.DataAccess.Models;
using University.DataAccess.Repository;
using University.Services.DTOs;

namespace University.Services.DomainServices
{
    public class CourseServices : ICourseServices
    {
        private readonly IRepository _repository;
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;

        public CourseServices(IRepository repository, IStudentServices studentServices, IMapper mapper)
        {
            _repository = repository;
            _studentServices = studentServices;
            _mapper = mapper;
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
            CourseDTO dto = _mapper.Map<CourseDTO>(course);
            return dto;
        }
        public List<Course> GetCoursesByStudentId(int studentId)
        {
            return _repository.Get<Student>(studentId).StudentCourses.Select(c => c.Course).ToList();
        }

        public AssignStudentsDTO GetAllStudentWithCourseToAssign(int courseId)
        {
            var course =  GetCourse(courseId);
            var dto = _mapper.Map<AssignStudentsDTO>(course);
            var students = _studentServices.GetListStudentDTO();

            dto.StudentList = students.Select(s => new SelectListItem
            {
                Text = s.FullName,
                Value = s.Id.ToString()
            });
            return dto;
        }

        public void AddCourse(CourseDTO courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
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


        public void AssgineStudentsToCourse(AssignStudentsDTO assignStudentsDTO)
        {
            var list = new List<StudentCourse>();
            var courseFromDb = GetCourse(assignStudentsDTO.Id);
            foreach (var studentId in assignStudentsDTO.StudentsIds)
            {
                var relation = new StudentCourse()
                {
                    StudentId = studentId,
                    CourseId = courseFromDb.Id,
                };
                list.Add(relation);
            }
           // courseFromDb.StudentCourses = new List<StudentCourse>();
            courseFromDb.StudentCourses = list;
            _repository.Update(courseFromDb);
        }
    }
}
