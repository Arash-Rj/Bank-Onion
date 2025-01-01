using Src.Domain.Core.Bnak.Cards.Entities;
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
        public List<Card>? GetCards(int id);
        public List<User>? GetAll();
        public void Update(User user);
           
    }
}
