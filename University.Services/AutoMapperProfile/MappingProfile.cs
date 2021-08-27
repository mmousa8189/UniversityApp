using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess.Models;
using University.Services.DTOs;

namespace University.Services.AutoMapperProfile
{
   public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            #region [Student - StudentDTO - Mapping]
            CreateMap<Student, StudentDTO>().ReverseMap().
                ForMember(dist => dist.CreatedDate, opt => opt.Ignore()).
                ForMember(dist => dist.GradeId, opt => opt.Ignore()).
                ForMember(dist => dist.Grade, opt => opt.Ignore()).
                ForMember(dist => dist.UpdatedDate, opt => opt.Ignore());

            CreateMap<Student, StudentDTO>().
                ForMember(dist => dist.FullName, opt => opt.Ignore());
            #endregion

            #region [Course - CourseDTO - Mapping]

            CreateMap<Course, CourseDTO>().ReverseMap().
                ForMember(dist => dist.CreatedDate, opt => opt.Ignore()).
                ForMember(dist => dist.StudentCourses, opt => opt.Ignore()).
                ForMember(dist => dist.UpdatedDate, opt => opt.Ignore());

            CreateMap<Course, CourseDTO>();
            #endregion
            #region [Course - AssignStudentsDTO - Mapping]
            

            CreateMap<Course, AssignStudentsDTO>().ReverseMap().
                ForMember(dist => dist.CourseName, opt => opt.MapFrom(src => src.CourseName)).
                ForMember(dist => dist.Id, opt => opt.MapFrom(src => src.Id)).
                ForMember(dist => dist.CreatedDate, opt => opt.Ignore()).
                ForMember(dist => dist.StudentCourses, opt => opt.Ignore()).
                ForMember(dist => dist.UpdatedDate, opt => opt.Ignore());

            CreateMap<Course, AssignStudentsDTO>().
                 ForMember(dist => dist.CourseName, opt => opt.MapFrom(src => src.CourseName)).
                 ForMember(dist => dist.Id, opt => opt.MapFrom(src => src.Id)).
                 ForMember(dist => dist.StudentList, opt => opt.Ignore()).
                 ForMember(dist => dist.StudentsIds, opt => opt.Ignore());
            #endregion

        }
    }
}
