using BaseDeDatos.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDatos.Repository
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        private readonly FedeBaseContext _context;

        public RepositoryGeneric(FedeBaseContext context)
        {
            _context = context;
        }

        DbSet<T> EntitySet
        {
            get
            {
                return _context.Set<T>();
            }
        }

        public async Task<T> CreateAsync(T entity)
        {
            _context.Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public T GetAsync(int id)
        {
            T entity = EntitySet.Find(id);

            return entity;
        }

        public IEnumerable<T> ListAsync()
        {
            IEnumerable<T> entitys = EntitySet.ToList();

            return entitys;
        }

        public async Task UpdateAsync(T entityUpdate)
        {
            _context.Entry(entityUpdate).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<T> DeleteAsync(int id)
        {
            T entity = await EntitySet.FindAsync(id);

            EntitySet.Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

    }
}
