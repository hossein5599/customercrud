using Domain.Entities.Customers;
using MohammadHosseinSadeghiCrudTest.Data;
using MohammadHosseinSadeghiCrudTest.Infrustracture;
using MohammadHosseinSadeghiCrudTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohammadHosseinSadeghiCrudTest.Repositories
{
    public class CustomerRepository : GenericRepository<Customer> , ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        public Task<Customer> GetById(int id)
        {
            return base.GetById(id);
        }

       
        public Task Update(Customer entity)
        {
            return  base.Update(entity);
                
        }

        public Task Create(Customer entity)
        {
            return base.Create(entity);
        }

        public Task Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
