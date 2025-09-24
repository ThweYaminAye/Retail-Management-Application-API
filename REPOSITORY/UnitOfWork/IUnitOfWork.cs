using MODEL.CommonConfig;
using REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace REPOSITORY.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductsRepository Products { get; }
        ISalesRepository Sales { get; }
        IFilesRepository Files { get; }
        IUsersRepository Users { get; }
        IUserRoleRepository UserRole { get; }
        ITEmp_RoleRepository TEmp_Role { get; }
        ITEmp_GroupRepository TEmp_Group { get; }
        IMemberInfoRepository MemberInfo { get; }
        IEmployeeEXTRepository EmployeeEXT { get; }
        IGroupRepository Group { get; }
        IUsersInfoRepository UserInfo { get; }
        AppSettings AppSettings();
        Task<int> SaveChangesAsync();

    }
}
