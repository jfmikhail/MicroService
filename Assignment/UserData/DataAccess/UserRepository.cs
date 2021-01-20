using System;
using System.Collections.Generic;
using System.Text;
using UserData.DatabaseModel;
using UserData.Models;

namespace UserData.DataAccess
{
    public class UserRepository:GenericRepository<User>, IUserRepository
    {
        public UserRepository(UserContext userContext) : base(userContext)
        {

        }
    }
}
