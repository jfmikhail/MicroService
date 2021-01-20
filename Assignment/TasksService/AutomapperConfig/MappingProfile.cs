using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskBusiness.ViewModels;
using TaskData.Models;

namespace TasksService.AutomapperConfig
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Task, TaskVm>();
            CreateMap<TaskVm, Task>();
        }
    }
}
