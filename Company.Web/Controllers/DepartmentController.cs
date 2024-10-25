﻿using Company.Data.Contexts.Configurations;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Repository.Repositories;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Department.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var departments = _departmentService.GetAll();
            return View(departments);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentDto department)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);
                    return RedirectToAction(nameof(Index));

                }
                ModelState.AddModelError("DepartmentError", "VaildationErrors");
                //return RedirectToAction(nameof(Index));
                return View(department);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmentError", ex.Message);
                return View(department);
            }
        }


        public IActionResult Details(int? id, string ViewName = "Details")
        {
            var department= _departmentService.GetById(id);


            if (department == null)

                return NotFound();
            return View(ViewName,department);



        }


        public IActionResult Update(int? id)
        {
          return Details(id, "Update");

        }


        [HttpPost]
        public IActionResult Update(int? id, DepartmentDto department)
        {
            if (department.Id != id.Value)
            
                return NotFound();




                _departmentService.Update(department);

                return RedirectToAction(nameof(Index));
            
        }


        public IActionResult Delete(int id)
        {
            var department = _departmentService.GetById(id);


            if (department == null)

                return NotFound();


         _departmentService.Delete(department);
            return RedirectToAction(nameof(Index));



        }


    }
    
}
