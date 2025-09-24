using REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL.Entities;
using MODEL;

namespace REPOSITORY.Repository
{
    public class UsersInfoRepository:GenericRepository<UserInfo>, IUsersInfoRepository
    {
        public UsersInfoRepository(DataContext dataContext) : base(dataContext) { }
    }
}
