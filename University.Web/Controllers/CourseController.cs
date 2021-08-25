using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.DataAccess.Models;
using University.DataAccess.Repository;

namespace University.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly IRepository _repository;

        public CourseController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
           var courses = _repository.GetAll<Course>().ToList();
            return View();
        }
    }
}
