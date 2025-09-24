using System;
using MODEL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPOSITORY;

namespace REPOSITORY.IRepository
{
    public interface IUsersRepository : IGenericRepository<Users>
    { 
    }
}
