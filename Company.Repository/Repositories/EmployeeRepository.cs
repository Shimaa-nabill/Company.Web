using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee> ,IEmployeeRepository
    {


       
    private readonly CompanyDbContext _Context;
    public EmployeeRepository(CompanyDbContext context) : base(context)
    {
        _Context = context;
    }

        public IEnumerable<Employee> GetEmployeeName(string Name)
       => _Context.Employees.Where(X=> X.Name.Trim().ToLower().Contains(Name.Trim().ToLower())).ToList();
    }
}
