using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserData.Models;

namespace UserData.DatabaseModel
{
    public class UserContext:DbContext, IDbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
                modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        Id=1,
                        Name="Carter"
                    },
                    new User()
                    {
                        Id = 2,
                        Name ="John"
                    },
                    new User()
                    {
                        Id = 3,
                        Name ="Mina"
                    }
                );
        }
    }
}
