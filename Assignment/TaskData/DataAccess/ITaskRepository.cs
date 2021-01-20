using System;
using System.Collections.Generic;
using System.Text;
using TaskData.Models;

namespace TaskData.DataAccess
{
    public interface ITaskRepository: IGenericRepository<Task>
    {
    }
}
