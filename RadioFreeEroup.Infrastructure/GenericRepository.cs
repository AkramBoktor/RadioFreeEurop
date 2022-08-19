using Microsoft.EntityFrameworkCore;
using RadioFreeEroup.Domain.Interfaces;
using RadioFreeEroup.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RadioFreeEroup.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly JsonItemContext _context;
        internal DbSet<T> dbSet;

        public GenericRepository(JsonItemContext jsonBase64Context)
        {
            _context = jsonBase64Context;
            this.dbSet = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
             await dbSet.AddAsync(entity);

        }

        public async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();

        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var Ts = await dbSet.FindAsync(id);
                if (Ts == null)
                {
                    dbSet.Remove(Ts);
                }
                else
                {
                    return false;
                }

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            };

        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).FirstOrDefaultAsync();
        }


        public async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

     
    }
}
