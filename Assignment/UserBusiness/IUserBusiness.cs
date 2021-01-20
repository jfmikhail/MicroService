using System;
using System.Collections.Generic;
using System.Text;
using UserBusiness.ViewModels;

namespace UserBusiness
{
    public interface IUserBusiness
    {
        ServiceResponseDto<List<UserVm>> GetAllUsers();
        ServiceResponseDto<UserVm> UpdateUser(UserVm pUserVm);
        ServiceResponseDto<UserVm> CreateUser(UserVm pUserVm);
        ServiceResponseDto<bool> DeleteUser(int pUserId);
    }
}
