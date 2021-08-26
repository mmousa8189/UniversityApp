using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Services.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(10)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        [Required]
        [Range(0,250)]
        public float Height { get; set; }
        [Required]
        [Range(0, 200)]
        public float Weight { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
