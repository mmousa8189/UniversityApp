using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace University.Services.DTOs
{
   public class AssignStudentsDTO
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        [Display(Name = "Students")]
        public int[] StudentsIds { get; set; }
        public IEnumerable<SelectListItem> StudentList { get; set; }
    }
}
