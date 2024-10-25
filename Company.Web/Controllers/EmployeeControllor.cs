using Company.Data.Models;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;
using Company.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        [HttpGet]
       



         public IActionResult Index(string searchInp)
        {
            
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();
            if (string.IsNullOrEmpty(searchInp))
                employees = _employeeService.GetAll();
            else
                employees = _employeeService.GetEmployeeName(searchInp);
                 
                 
            return View(employees);

        }





        public IActionResult Create()
        {

            ViewBag.Departments = _departmentService.GetAll();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeDto employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Add(employee);
                return RedirectToAction("Index");
            }

            
            ViewBag.Departments = _departmentService.GetAll();
            return View(employee);
        }




        public IActionResult Details(int? id, string viewName = "Details")
        {
            var emp = _employeeService.GetById(id.Value);
            if (emp is null)
                return RedirectToAction("NotFoundPage", null, "Home");

            return View(viewName, emp);
        }



        public ActionResult Delete(int id)
        {
            var emp = _employeeService.GetById(id);
            if (emp is null)
                return RedirectToAction("NotFoundPage", null, "Home");
            _employeeService.Delete(emp);

            return RedirectToAction("Index");
        }


        public IActionResult Update(int? id)
        {
            return Details(id, "Update");
        }
        [HttpPost]
        public IActionResult Update(int? id, EmployeeDto employee)
        {
            if (employee.Id != id!.Value)
                return RedirectToAction("NotFoundPage", null, "Home");

            _employeeService.Update(employee);
            return RedirectToAction("Index");
        }



    }
}
