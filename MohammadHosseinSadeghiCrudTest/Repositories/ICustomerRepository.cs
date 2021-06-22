using Domain.Entities.Customers;
using MohammadHosseinSadeghiCrudTest.Infrustracture;
using MohammadHosseinSadeghiCrudTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohammadHosseinSadeghiCrudTest.Repositories
{
  public  interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllAsync();

        Task<Customer> GetById(int id);

        Task Create(Customer entity);

        Task Update(Customer entity);

        Task Delete(int id);
    }
}
