using Microsoft.EntityFrameworkCore;
using PersonalApp.Data;
using PersonalApp.Dto;
using PersonalApp.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly MyAppDbContext _dbContext;

        public Repository(MyAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
           await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
             _dbContext.Set<T>().Remove(entity);
            int row =await _dbContext.SaveChangesAsync();
            return row >0;
        }

        public async Task<IEnumerable<T>> GetAllAsyc()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
             _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}

