using MODEL.DTO;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Object>> GetEmployeeByCompanyID(Guid id);
        Task<UserInfo> AddNewUser(UserInfoDTO user);
        Task<string> Login(LoginDTO loginInput);
    }
}
