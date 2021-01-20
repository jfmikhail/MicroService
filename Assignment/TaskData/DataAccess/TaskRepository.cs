using System;
using System.Collections.Generic;
using System.Text;
using TaskData.DatabaseModel;
using TaskData.Models;

namespace TaskData.DataAccess
{
    public class TaskRepository:GenericRepository<Task>, ITaskRepository
    {
        public TaskRepository(TaskContext taskContext) : base(taskContext)
        {

        }
    }
}
