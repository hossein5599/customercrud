using MohammadHosseinSadeghiCrudTest.Data;
using MohammadHosseinSadeghiCrudTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohammadHosseinSadeghiCrudTest.Infrustracture
{
   
        public class UnitOfWork : IUnitOfWork
        {
            private readonly ApplicationDbContext _context;
            public ICustomerRepository Customer { get;  }


        public UnitOfWork(ApplicationDbContext bookStoreDbContext,
                ICustomerRepository studentsRepository)
            {
                this._context = bookStoreDbContext;
                this.Customer = studentsRepository;
               
            }
            public async Task<int> CompleteAsync()
            {
                return await _context.SaveChangesAsync();
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        
    }
}
