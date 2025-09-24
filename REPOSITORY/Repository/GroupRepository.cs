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
    public class GroupRepository : GenericRepository<Group> , IGroupRepository
    {
        public GroupRepository(DataContext dataContext) : base(dataContext) { }
    }
}
