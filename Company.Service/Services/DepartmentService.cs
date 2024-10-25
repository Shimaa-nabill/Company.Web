using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Service.Interfaces.Department.Dto;
using AutoMapper;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
           _mapper = mapper;
        }

        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new Department
            //{
            //    Code = department.Code,
            //    Name = department.Name,
            //    CreateAt = DateTime.Now
            //};
             var mappedDepartment= _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Add(mappedDepartment);
            _unitOfWork.complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            var mappedDepartment = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Delete(mappedDepartment);
            _unitOfWork.complete();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
           
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var mappedDepartments = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return mappedDepartments;

        }

        public DepartmentDto GetById(int? id)
        {
            if (id == null)
                return null;

            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);

            if (department == null)
                return null;

            var mappedDepartment = _mapper.Map<DepartmentDto>(department);
            return mappedDepartment;
        }

        public void Update(DepartmentDto department)
        {
        //    _unitOfWork.DepartmentRepository.Update(department);
        //    _unitOfWork.complete();
        }



    }
}