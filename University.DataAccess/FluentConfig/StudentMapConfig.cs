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
   public class StudentMapConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> modelBuilder)
        {
            //Student
            modelBuilder.HasKey(s => s.Id);
            modelBuilder.HasOne(s => s.Grade).WithMany(g => g.Students).HasForeignKey(s => s.GradeId);

            modelBuilder.Ignore(a => a.FullName);

        }
    }
}
