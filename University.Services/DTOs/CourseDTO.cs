using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Services.DTOs
{
   public class CourseDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string CourseName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
    }
}
