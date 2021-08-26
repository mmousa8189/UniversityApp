using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess.Models;
using University.Services.DTOs;

namespace University.Services.DomainServices
{
   public interface IStudentServices
    {
        public void AddStudent(StudentDTO studentDTO);
        public void DeleteStudent(int id);
        public List<Student> GetAll();
        List<StudentDTO> GetListStudentDTO();
        public Student GetStudent(int StudentId);
        public StudentDTO GetStudentDTO(int StudentId);
        public void UpdateStudent(StudentDTO StudentDto);
    }
}
