using REPOSITORY.IRepository;
using System;
using MODEL.Entities;
using MODEL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Repository
{
    public class TEmp_GroupRepository : GenericRepository<TEmp_Group>, ITEmp_GroupRepository
    {
        public TEmp_GroupRepository(DataContext dataContext) : base(dataContext) { }
    }
}
