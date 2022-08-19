using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RadioFreeEroup.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(Guid id);
        Task Add(T entity);
        Task<bool> Delete(Guid id);

        Task<T> Find(Expression<Func<T, bool>> predicate);
    }
}


