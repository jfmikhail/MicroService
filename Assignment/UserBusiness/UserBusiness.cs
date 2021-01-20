using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using UserBusiness.ViewModels;
using UserData.DataAccess;
using UserData.Models;

namespace UserBusiness
{
    public class UserBusiness:IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserBusiness(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ServiceResponseDto<List<UserVm>> GetAllUsers(){
            ServiceResponseDto<List<UserVm>> retVal;
            try
            {
                var users = _userRepository.GetAll().ToList();
                var usersVm = _mapper.Map<List<UserVm>>(users);
                retVal = SR.Successfull<List<UserVm>>(usersVm);
            }
            catch(Exception ex)
            {
                retVal = SR.Failed<List<UserVm>>(ex, "GetAllUsers");
            }
            return retVal;
        }

        public ServiceResponseDto<UserVm> UpdateUser(UserVm pUserVm)
        {
            ServiceResponseDto<UserVm> retVal;
            try
            {
                var lUserToUpdate = _userRepository.Get(pUserVm.Id);
                lUserToUpdate.Name = pUserVm.Name;
                var lUpdatedUser = _userRepository.Update(lUserToUpdate, pUserVm.Id);
                var lUpdatedUserVm = _mapper.Map<UserVm>(lUpdatedUser);
                retVal = SR.Successfull<UserVm>(lUpdatedUserVm);
            }
            catch (Exception ex)
            {
                retVal = SR.Failed<UserVm>(ex, "UpdateUser");
            }
            return retVal;
        }

        public ServiceResponseDto<UserVm> CreateUser(UserVm pUserVm)
        {
            ServiceResponseDto<UserVm> retVal;
            try
            {
                var lNewUser = _mapper.Map<User>(pUserVm);
                var lCreatedUser = _userRepository.Insert(lNewUser);
                var lCreatedUserVm = _mapper.Map<UserVm>(lCreatedUser);
                retVal = SR.Successfull<UserVm>(lCreatedUserVm);
            }
            catch (Exception ex)
            {
                retVal = SR.Failed<UserVm>(ex, "CreateUser");
            }
            return retVal;
        }

        public ServiceResponseDto<bool> DeleteUser(int pUserId)
        {
            ServiceResponseDto<bool> retVal;
            try
            {
                var lUserToDelete = _userRepository.Get(pUserId);
                _userRepository.Delete(lUserToDelete);
                retVal = SR.Successfull<bool>(true);
            }
            catch (Exception ex)
            {
                retVal = SR.Failed<bool>(ex, "DeleteUser");
            }
            return retVal;
        }
    }
}
