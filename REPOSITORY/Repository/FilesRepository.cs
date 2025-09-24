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
    public class FilesRepository : GenericRepository<Files>, IFilesRepository
    {
        public FilesRepository(DataContext  dataContext) : base(dataContext) { }
    }
}
