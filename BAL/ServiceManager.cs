using Microsoft.Extensions.DependencyInjection;
using MODEL.CommonConfig;
using MODEL;
using REPOSITORY.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BAL.IService;
using BAL.Service;
using REPOSITORY.IRepository;
using REPOSITORY.Repository;

namespace BAL
{
    public class ServiceManager
    {
        public static void SetServiceInfo(IServiceCollection service, AppSettings appSettings)
        {
            service.AddDbContextPool<DataContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(appSettings.ConnectionStrings);
            });

            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IProductsService, ProductsService>();
            service.AddScoped<ISalesService, SalesService>();
            service.AddScoped<IFilesService, FilesService>();
            service.AddScoped<IUsersRepository, UsersRepository>();
            service.AddScoped<IEmployeeService, EmployeeService>();
            
            
            


        }
    }
}
