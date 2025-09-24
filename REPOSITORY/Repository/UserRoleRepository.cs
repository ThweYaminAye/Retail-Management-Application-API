using MODEL;
using MODEL.Entities;
using REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Repository
{
    public class UserRoleRepository : GenericRepository<UserRole> , IUserRoleRepository
    {
        public UserRoleRepository(DataContext dataContext) : base(dataContext) { }
    }
}
