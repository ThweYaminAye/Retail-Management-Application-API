using BAL.IService;
using Microsoft.Identity.Client;
using MODEL;
using MODEL.CommonConfig;
using MODEL.Entities;
using REPOSITORY.UnitOfWork;
using MODEL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        private readonly DataContext _dataContext;

        public EmployeeService(IUnitOfWork unitOfWork, AppSettings appSettings, DataContext dataContext)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings;
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            var data = await _unitOfWork.Users.GetByCondition(x => x.ActiveFlag == true);
            return data;

        }
        public async Task<IEnumerable<Object>> GetEmployeeByCompanyID(Guid id)
        {

            var query = from employee in _dataContext.EmployeeExt
                        where employee.CompanyId == id && employee.ActiveFlag == true

                        join user_data in _dataContext.Users on employee.UserID equals user_data.ID
                        where user_data.ActiveFlag == true 
                        //&& user_data.CompanyId == employee.CompanyId

                        join user_role in _dataContext.UserRole on user_data.RoleID equals user_role.UserRoleID
                        where user_role.ActiveFlag == true 
                        //&& user_role.CompanyID == user_data.CompanyId

                        join user_group in _dataContext.Group on user_role.UserRoleID equals user_group.RoleID
                        where user_group.ActiveFlag == true 
                        //&& user_role.CompanyID == user_group.CompanyId

                        join user_tempGroup in _dataContext.TEmp_Group on user_group.GroupID equals user_tempGroup.GroupID
                        where user_tempGroup.ActiveFlag == true

                        join member_info in _dataContext.MemberInfo on employee.MemberID equals member_info.MemberID
                        where member_info.ActiveFlag == true 
                        //&& employee.CompanyId == member_info.CompanyId

                        join user_tempRole in _dataContext.TEmp_Role on user_role.UserRoleID equals user_tempRole.TEmp_Role_ID
                        where user_tempRole.ActiveFlag == true 

                        select new
                        {
                            EmployeeID = employee.EmployeeID,
                            UserID = employee.UserID,
                            MemberID = employee.MemberID,
                            Name = user_data.FullName,
                            UserName = user_data.UserName,
                            Emial = user_data.Email,
                            Mobile = member_info.Mobile,
                            Gender = member_info.Gender,
                            ContactName = member_info.ContactName,
                            Position = user_data.Positions ,
                            UserType = user_data.UserType,
                            UserRole = user_role.RoleName,
                            Group = user_group.GroupName,
                            TempGuoupID = user_tempGroup.TEmp_Group_ID,
                            TempRoleID = user_tempRole.TEmp_Role_ID,
                        };

            //var employee = await _unitOfWork.EmployeeEXT.GetByCondition(x => x.ActiveFlag == true && x.CompanyId == id);
            //var member = await _unitOfWork.MemberInfo.GetByCondition(x => x.ActiveFlag == true && x.CompanyId == id);
            //var user = await _unitOfWork.Users.GetByCondition(x => x.ActiveFlag == true && x.CompanyId == id);
            //var userRole = await _unitOfWork.UserRole.GetByCondition(x => x.ActiveFlag == true && x.CompanyID == id);
            //var temp_Role = await _unitOfWork.TEmp_Role.GetByCondition(x => x.ActiveFlag == true);
            //var temp_Group = await _unitOfWork.TEmp_Group.GetByCondition(x => x.ActiveFlag == true);
            //var groups = await _unitOfWork.Group.GetByCondition(g => g.ActiveFlag == true);

            //var query = from emp in employee
            //                   join mem in member on emp.MemberID equals mem.MemberID into memGroup

            //                   from mem in memGroup.DefaultIfEmpty()
            //                   join u in user on emp.UserID equals u.ID into userGroup

            //                   from u in userGroup.DefaultIfEmpty()
            //                   join urole in userRole on u?.RoleID equals urole.UserRoleID into userRoleGroup

            //                   from urole in userRoleGroup.DefaultIfEmpty()
            //                   join temp_role in _dataContext.TEmp_Role on urole?.UserRoleID equals temp_role.RoleID into temproleGroup

            //                   from temp_role in temproleGroup.DefaultIfEmpty()
            //                   join temp_group in _dataContext.TEmp_Group on temp_role?.EmployeeID equals temp_group.EmployeeID into tempGroup

            //                   from temp_group in tempGroup.DefaultIfEmpty()
            //                   join g in _dataContext.Group on temp_group?.GroupID equals g.GroupID into ggroup

            //                   from g in ggroup.DefaultIfEmpty()
            //                   where emp?.CompanyId == mem?.CompanyId && mem?.CompanyId == u?.CompanyId && u?.CompanyId == urole?.CompanyID
            //                   where emp?.CompanyId == mem?.CompanyId && mem?.CompanyId == u?.CompanyId && u?.CompanyId == urole?.CompanyID

            //                   select new
            //                   {

            //                       Members = mem,
            //                       FullName = u.FullName,
            //                       Gender = u.Gender,
            //                       UserRole = urole?.UserRoleID
            //                       //TempRole = temp_role

            //                   };

            return query;
        }

        public async Task<UserInfo> AddNewUser(UserInfoDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            var query = new UserInfo()
            {
                UserID = new Guid(),
                UserName = user.UserName,
                UserPassword = user.UserPassword,
                UserEmail = user.UserEmail,
                UserPhone = user.UserPhone,
                UserAddress = user.UserAddress,
            };

            await _unitOfWork.UserInfo.Add(query);
            await _unitOfWork.SaveChangesAsync();

            return query;
        }

       
        public async Task<string> Login(LoginDTO loginInput)
        {
            var name = loginInput.UserName;
            var password = loginInput.UserPassword;

            var tokenGenerator = new TokenGenerator("eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTczMDEwOTE5MiwiaWF0IjoxNzMwMTA5MTkyfQ.p8Mu-kckLsYQO2X_CDnVikwPeyNxB6aLv74hhRNrADw");

            if (name == "admin" && password == "admin")
            {
                var token = tokenGenerator.GenerateToken(name, "admin");
                return token;
               
            }
            else if(name != null && password != null)
            {
                var data = (await _unitOfWork.UserInfo.GetByCondition(x => x.ActiveFlag == true && x.UserName == name && x.UserPassword == password)).FirstOrDefault();
                if (data != null)
                {
                    var token = tokenGenerator.GenerateToken(name, "user");
                    return token;
                }
                else
                {
                    throw new Exception("Errrorrrrrrrrr");
                }
            }
            else
            {
                throw new Exception("Wwwwwwwwwwwwwwwwwww");
            }
            

        }
    }
}
