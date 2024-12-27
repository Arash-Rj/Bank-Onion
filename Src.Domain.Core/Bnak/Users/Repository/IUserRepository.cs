using Src.Domain.Core.Bnak.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Bnak.Users.Repository
{
    public interface IUserRepository
    {
        bool AddUser(string name, string eamil, string password);
        public bool DoesUserExist(string eamil, string password);
        public User GetUserByEmail(string email);
    }
}
