using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess.Models;

namespace University.DataAccess.FluentConfig
{
    public class StudentCourseMapConfig:IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> modelBuilder)
        {
            //StudentCourse
            modelBuilder.HasKey(sc => new {sc.CourseId,sc.StudentId });
            modelBuilder.HasOne(sc => sc.Student).WithMany(s => s.StudentCourses).HasForeignKey(sc => sc.StudentId);
            modelBuilder.HasOne(sc => sc.Course).WithMany(s => s.StudentCourses).HasForeignKey(sc => sc.CourseId);


        }
    }
}
