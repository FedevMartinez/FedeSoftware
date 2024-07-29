using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos.Repository
{
    public interface IRepositoryGeneric<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task<T> DeleteAsync(int id);

        T GetAsync(int id);

        IEnumerable<T> ListAsync();
    }
}
