using MODEL;
using REPOSITORY.IRepository;
using MODEL.Entities;
using REPOSITORY.IRepository;

namespace REPOSITORY.Repository
{
    public class UsersRepository : GenericRepository<Users> , IUsersRepository
    {
        public UsersRepository(DataContext dbContext) : base(dbContext) { }
    }
}
