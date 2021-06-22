using MohammadHosseinSadeghiCrudTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohammadHosseinSadeghiCrudTest.Infrustracture
{
  public  interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetById(int? id);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(int id);

        bool Exists(object id);
    }
}
