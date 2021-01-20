using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskData.Models;

namespace TaskData.DatabaseModel
{
    public class TaskContext:DbContext, IDbContext
    {
        public virtual DbSet<Task> Tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
