using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess.Models;
using University.DataAccess.Repository;
using University.Services.DTOs;

namespace University.Services.DomainServices
{
    public class StudentServices : IStudentServices
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public StudentServices(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddStudent(StudentDTO studentDTO)
        {
            
            var student = _mapper.Map<Student>(studentDTO);
            _repository.Insert(student);
        }

        public void DeleteStudent(int id)
        {
            var objFromDb = GetStudent(id);
            _repository.Delete(objFromDb);
        }

        public List<Student> GetAll()
        {
            return _repository.GetAll<Student>().ToList();
        }
        public List<StudentDTO> GetListStudentDTO()
        {
            return _repository.GetAll<Student>().Select(s=> new StudentDTO 
            { 
             FirstName = s.FirstName,
             LastName = s.LastName,
             Id = s.Id
            }).ToList();
        }

        public Student GetStudent(int studentId)
        {
            return _repository.Get<Student>(studentId);
        }

        public StudentDTO GetStudentDTO(int studentId)
        {
            var student = _repository.Get<Student>(studentId);
            StudentDTO dto =  _mapper.Map<StudentDTO>(student);
            return dto;
        }

        public void UpdateStudent(StudentDTO studentDto)
        {
            var studentFromDb = GetStudent(studentDto.Id);
            studentFromDb.FirstName = studentDto.FirstName;
            studentFromDb.LastName = studentDto.LastName;
            studentFromDb.DateOfBirth = studentDto.DateOfBirth;
            studentFromDb.Height = studentDto.Height;
            studentFromDb.Weight = studentDto.Weight;
            _repository.Update(studentFromDb);
        }

    }
}
