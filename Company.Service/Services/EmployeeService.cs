using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Service.Interfaces.Employee.Dto;
using AutoMapper;
using Company.Service.Helper;
namespace Company.Service.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto employeedto)
        {
            employeedto.ImageUrl = DocumentSettings.UploadFiles(employeedto.Image, "Images");
            Employee employee = _mapper.Map<Employee>(employeedto);
            _unitOfWork .EmployeeRepository.Add(employee);
            _unitOfWork.complete();

        }

        public void Delete(EmployeeDto employeedto)
        {
            Employee employee = _mapper.Map<Employee>(employeedto);
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.complete();
        }
        

        public IEnumerable<EmployeeDto> GetAll()
        {

            var Employees = _unitOfWork.EmployeeRepository.GetAll();

            IEnumerable <EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(Employees);

            return mappedEmployees;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id == null)
                return null;

            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);

            if (employee == null)
                return null;
            EmployeeDto employeeDto =_mapper.Map<EmployeeDto>(employee);

                

            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeeName(string name)
        {


            var employees = _unitOfWork.EmployeeRepository.GetEmployeeName(name);

            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return mappedEmployees;

        }
        public void Update(EmployeeDto employee)
        {

            //_unitOfWork.EmployeeRepository.Update(employee);
            //_unitOfWork.complete();
        }
    }
}
