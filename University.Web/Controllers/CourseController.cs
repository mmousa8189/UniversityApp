using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.DataAccess.Models;
using University.DataAccess.Repository;
using University.Services;
using University.Services.DomainServices;
using University.Services.DTOs;

namespace University.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseServices _courseServices;
        private readonly INotyfService _notyf;
        private readonly IRepository _repository;

        public CourseController(ICourseServices courseServices, INotyfService notyf, IRepository repository)
        {
            _courseServices = courseServices;
            _notyf = notyf;
            _repository = repository;
        }
        public IActionResult Index()
        {
            var list = _courseServices.GetAll();
            var listInc = _repository.GetQueryable<Course>().Include(c => c.StudentCourses).ToList();
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


        public IActionResult AssignStudents(int? id)
        {
            if (!id.HasValue)
                return NotFound();
            var list = _courseServices.GetAllStudentWithCourseToAssign(id.Value);
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssignStudents(AssignStudentsDTO assignStudentsDTO)
        {
            _courseServices.AssgineStudentsToCourse(assignStudentsDTO);
            _notyf.Success($"Success Assign Students  to Course {assignStudentsDTO.CourseName}");
            return RedirectToAction(nameof(Index));
        }

    }
}
