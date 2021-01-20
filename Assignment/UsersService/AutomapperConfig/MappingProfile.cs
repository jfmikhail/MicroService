using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBusiness.ViewModels;
using UserData.Models;

namespace UsersService.AutomapperConfig
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserVm>();
            CreateMap<UserVm, User>();
        }
    }
}
