using System;
using MODEL;
using MODEL.Entities;
using MODEL.CommonConfig;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using REPOSITORY.IRepository;
using REPOSITORY.Repository;


namespace REPOSITORY.UnitOfWork
{
    
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;

        public UnitOfWork(DataContext context, IOptions<AppSettings> appsettings)
        {
            _context = context;

            AppSettings = appsettings.Value;

            Products = new ProductsRepository(_context);

            Sales = new SalesRepository(_context);

            Users = new UsersRepository(_context);
            
            UserRole = new UserRoleRepository(_context);

            TEmp_Role = new TEmp_RoleRepository(_context);

            TEmp_Group = new TEmp_GroupRepository(_context);

            Group = new GroupRepository(_context);
            
            MemberInfo = new MemberInfoRepository(_context);

            EmployeeEXT = new EmployeeEXTRepository(_context);

            Files = new FilesRepository(_context);

            UserInfo = new UsersInfoRepository(_context);

        }

        public IProductsRepository Products { get; set; }
        public ISalesRepository Sales { get; set; }
        
        public IUsersRepository Users { get; set; }
        public IUserRoleRepository UserRole { get; set; }

        public ITEmp_RoleRepository TEmp_Role { get; set; }
        public ITEmp_GroupRepository TEmp_Group { get; set; }

        public IGroupRepository Group { get; set; }

        public IMemberInfoRepository MemberInfo { get; set; }

        public IEmployeeEXTRepository EmployeeEXT { get; set; }

        public IFilesRepository Files { get; set; }
        public IUsersInfoRepository UserInfo { get; set; }
        public AppSettings AppSettings { get; set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        AppSettings IUnitOfWork.AppSettings()
        {
            throw new NotImplementedException();
        }
    }
}
