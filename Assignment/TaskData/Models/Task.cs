using System;
using System.Collections.Generic;
using System.Text;

namespace TaskData.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public int UserId { get; set; }
    }
}
