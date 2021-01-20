using System;
using System.Collections.Generic;
using System.Text;

namespace TaskBusiness.ViewModels
{
    public class TaskVm
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public int UserId { get; set; }
    }
}
