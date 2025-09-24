using REPOSITORY.IRepository;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace REPOSITORY.Repository
{
    public class TEmp_RoleRepository : GenericRepository<TEmp_Role> , ITEmp_RoleRepository
    {
        public TEmp_RoleRepository(DataContext dataContext) : base(dataContext) { }
    }
}
