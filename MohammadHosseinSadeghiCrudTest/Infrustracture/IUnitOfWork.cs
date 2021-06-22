using MohammadHosseinSadeghiCrudTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohammadHosseinSadeghiCrudTest.Infrustracture
{
  public  interface IUnitOfWork : IDisposable 
    {
        ICustomerRepository Customer { get; }
        Task<int> CompleteAsync();



        //ViewRepository ViewRepository { get; }
        //SiteRepository SiteRepository { get; }
        // ViewerRepository ViewerRepository { get; }
        // ContactRepository ContactRepository { get; }
        //CategoryRepository CategoryRepository { get; }
        //AdminUserRepository AdminRepository { get; }
        //LogsRepository LogsRepository { get; }
        // RoleRepository RoleRepository { get; }

        //  AdminRoleRepository AdminRoleRepository { get; }

        //SitePageRepository SitePageRepository { get; }
    }
}
