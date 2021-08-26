﻿using System;
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
        public CourseServices(IRepository repository, IStudentServices studentServices)
        {
            _repository = repository;
            _studentServices = studentServices;
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

        public AssignStudentsDTO GetAllStudentWithCourseToAssign(int courseId)
        {
            var dto = new AssignStudentsDTO();
            dto.Id =  GetCourse(courseId).Id;
            dto.CourseName =  GetCourse(courseId).CourseName;
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