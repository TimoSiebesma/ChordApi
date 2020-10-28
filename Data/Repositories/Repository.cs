using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChordApi.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> Entities { get; set; }

        public Repository(ChordApiContext context)
        {
            Entities = context.Set<T>();
        }

        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        public T GetById(int id)
        {
            return Entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Entities.ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Entities.AddRange(entities);
        }

        public void Remove(T entity)
        {
            Entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Entities.RemoveRange(entities);
        }
    }
}
