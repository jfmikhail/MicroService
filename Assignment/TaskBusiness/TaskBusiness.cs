using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskBusiness.ViewModels;
using TaskData.DataAccess;
using TaskData.Models;

namespace TaskBusiness
{
    public class TaskBusiness:ITaskBusiness
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskBusiness(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public ServiceResponseDto<List<TaskVm>> GetUserTasks(int userId){
            ServiceResponseDto<List<TaskVm>> retVal;
            try
            {
                var userTasks = _taskRepository.GetAll().Where(t=>t.UserId == userId).ToList();
                var userTasksVm = _mapper.Map<List<TaskVm>>(userTasks);
                retVal = SR.Successfull<List<TaskVm>>(userTasksVm);
            }
            catch(Exception ex)
            {
                retVal = SR.Failed<List<TaskVm>>(ex, "GetUserTasks");
            }
            return retVal;
        }

        public ServiceResponseDto<TaskVm> UpdateTask(TaskVm pTaskVm)
        {
            ServiceResponseDto<TaskVm> retVal;
            try
            {
                var lTaskToUpdate = _taskRepository.Get(pTaskVm.Id);
                lTaskToUpdate.Description = pTaskVm.Description;
                lTaskToUpdate.State = pTaskVm.State;
                var lUpdatedTask = _taskRepository.Update(lTaskToUpdate, pTaskVm.Id);
                var lUpdatedTaskVm = _mapper.Map<TaskVm>(lUpdatedTask);
                retVal = SR.Successfull<TaskVm>(lUpdatedTaskVm);
            }
            catch (Exception ex)
            {
                retVal = SR.Failed<TaskVm>(ex, "UpdateTask");
            }
            return retVal;
        }

        public ServiceResponseDto<TaskVm> CreateTask(TaskVm pTaskVm)
        {
            ServiceResponseDto<TaskVm> retVal;
            try
            {
                var lNewTask = _mapper.Map<Task>(pTaskVm);
                var lCreatedTask = _taskRepository.Insert(lNewTask);
                var lCreatedTaskVm = _mapper.Map<TaskVm>(lCreatedTask);
                retVal = SR.Successfull<TaskVm>(lCreatedTaskVm);
            }
            catch (Exception ex)
            {
                retVal = SR.Failed<TaskVm>(ex, "CreateTask");
            }
            return retVal;
        }

        public ServiceResponseDto<bool> DeleteUserTasks(int userId)
        {
            ServiceResponseDto<bool> retVal;
            try
            {
                var userTasks = _taskRepository.GetAll().Where(t => t.UserId == userId).ToList();
                foreach (var task in userTasks)
                    _taskRepository.Delete(task);
                retVal = SR.Successfull<bool>(true);
            }
            catch (Exception ex)
            {
                retVal = SR.Failed<bool>(ex, "DeleteUserTasks");
            }
            return retVal;
        }

    }
}
