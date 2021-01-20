using System;
using System.Collections.Generic;
using System.Text;
using TaskBusiness.ViewModels;

namespace TaskBusiness
{
    public interface ITaskBusiness
    {
        ServiceResponseDto<List<TaskVm>> GetUserTasks(int userId);
        ServiceResponseDto<TaskVm> UpdateTask(TaskVm pTaskVm);
        ServiceResponseDto<TaskVm> CreateTask(TaskVm pUserVm);
        ServiceResponseDto<bool> DeleteUserTasks(int userId);
    }
}
