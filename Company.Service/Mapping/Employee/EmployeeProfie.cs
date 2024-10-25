using AutoMapper;
using Company.Data.Models;
using Company.Service.Interfaces.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Mapping
{
    public class EmployeeProfie :Profile
    {

        public EmployeeProfie() 
        {
        CreateMap<Employee ,EmployeeDto>().ReverseMap();
        }
    }
}
