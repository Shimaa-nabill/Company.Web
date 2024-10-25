using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity

    {
        private readonly CompanyDbContext _Context;
        public GenericRepository(CompanyDbContext context) 
        { 
            _Context = context;
        }
        public void Add(T entity)
        {
          _Context.Set<T>().Add(entity);
           
        }

       

        public void Delete(T entity)
            => _Context.Set<T>().Remove(entity);


        public IEnumerable<T> GetAll()
           => _Context.Set<T> ().ToList();

        public T GetById(int id)

        => _Context.Set<T>().Find(id);

        public void Update(T entity)
        {
            _Context.Set<T>().Update(entity);
          
        }
    }
}
