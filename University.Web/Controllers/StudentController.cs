using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Services.DomainServices;
using University.Services.DTOs;

namespace University.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentServices _studentServices;
        private readonly INotyfService _notyf;

        public StudentController(IStudentServices studentServices, INotyfService notyf)
        {
            _studentServices = studentServices;
            _notyf = notyf;
        }
        // GET: StudentController
        public IActionResult Index()
        {
            var list = _studentServices.GetAll();
            return View(list);
        }

        // GET: StudentController/Details/5
        //public IActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: StudentController/Create
        public IActionResult Create()
        {
            StudentDTO studentDTO = new StudentDTO();
            return View(studentDTO);
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentDTO studentDTO)
        {
            _studentServices.AddStudent(studentDTO);
            _notyf.Success($"Success Create Student {studentDTO.FullName}");
            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return NotFound();
            var studentDTO = _studentServices.GetStudentDTO(id.GetValueOrDefault());
            return View(studentDTO);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentDTO studentDTO)
        {
            _studentServices.UpdateStudent(studentDTO);
            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Delete/5
       
        public IActionResult Delete(int id)
        {
            _studentServices.DeleteStudent(id);
            _notyf.Success("Success Delete Student");
            return RedirectToAction(nameof(Index));
        }

      
    }
}
