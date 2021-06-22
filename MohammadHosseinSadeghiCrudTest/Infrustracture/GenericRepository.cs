using Microsoft.EntityFrameworkCore;
using MohammadHosseinSadeghiCrudTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MohammadHosseinSadeghiCrudTest.Models;

namespace MohammadHosseinSadeghiCrudTest.Infrustracture
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<TEntity> entities;
        string errorMessage = string.Empty;
        public GenericRepository(ApplicationDbContext context)
        {
            this._dbContext = context;
            entities = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetById(int? id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
                        //.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
           // await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
          //  await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public  bool Exists(object id)
        {
            return _dbContext.Set<TEntity>().Any(i => i == id);


            //throw new NotImplementedException();
        }
    }
}
