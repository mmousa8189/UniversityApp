using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.DataAccess.Models;
using University.DataAccess.Repository;
using University.Services;
using University.Services.DTOs;

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
            CourseDTO courseDto = new CourseDTO();
            return View(courseDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseDTO courseDto)
        {
            _courseServices.AddCourse(courseDto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return NotFound();
            var courseDto = _courseServices.GetCourseDTO(id.GetValueOrDefault());
            return View(courseDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourseDTO courseDto)
        {
            _courseServices.UpdateCourse(courseDto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _courseServices.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AssignStudents()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssignStudents(Course course)
        {
            throw new NotImplementedException();
        }

    }
}
