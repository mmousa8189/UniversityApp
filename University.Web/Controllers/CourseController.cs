using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.DataAccess.Models;
using University.DataAccess.Repository;
using University.Services;

namespace University.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseServices _courseServices;

        public CourseController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }
        public IActionResult Index()
        {
            var list = _courseServices.GetAll();
            return View(list);
        }
        public IActionResult Create()
        {
            Course course = new Course();
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            _courseServices.AddCourse(course);
            return RedirectToAction(nameof(Index));
        }

    }
}
