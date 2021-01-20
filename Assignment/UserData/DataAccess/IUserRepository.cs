using System;
using System.Collections.Generic;
using System.Text;
using UserData.Models;

namespace UserData.DataAccess
{
    public interface IUserRepository: IGenericRepository<User>
    {
    }
}
