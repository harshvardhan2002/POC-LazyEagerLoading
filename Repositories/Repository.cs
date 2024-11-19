using LazyEagerLoadingPOC.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace LazyEagerLoadingPOC.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeContext _context;
        private readonly DbSet<T> _table;

        public Repository(EmployeeContext context)
        {
            _context = context;
            _table=_context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }
    }
}
