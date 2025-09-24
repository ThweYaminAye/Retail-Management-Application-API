using System;
using MODEL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPOSITORY.IRepository;
using MODEL;

namespace REPOSITORY.Repository
{
    public class EmployeeEXTRepository : GenericRepository<EmployeeEXT>, IEmployeeEXTRepository
    {
        public EmployeeEXTRepository(DataContext dataContext) : base(dataContext) { }
    }
}
