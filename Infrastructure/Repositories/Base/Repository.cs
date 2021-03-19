using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Base;
using Core.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly MovieContext MovieContext;

        public Repository(MovieContext movieContext)
        {
            MovieContext = movieContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await MovieContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await MovieContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await MovieContext.Set<T>().AddAsync(entity);
            await MovieContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            MovieContext.Entry(entity).State = EntityState.Modified;

            await MovieContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            MovieContext.Set<T>().Remove(entity);
            await MovieContext.SaveChangesAsync();
        }
    }
}