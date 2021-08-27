using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess.Data;

namespace University.DataAccess.Models
{
   public class Grade: BaseEntity
    {
        public string GradeName { get; set; }
        public string Section { get; set; }

        public virtual IList<Student> Students { get; set; }
    }
}
