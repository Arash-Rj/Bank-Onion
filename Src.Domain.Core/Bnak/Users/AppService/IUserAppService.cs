
using Src.Domain.Core.Bnak.Cards.Entities;
using Src.Domain.Core.Bnak.ResultModel;
using Src.Domain.Core.Bnak.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Bnak.Users.AppService
{
    public interface IUserAppService
    {
        public Result Login(string email, string password);
        public Result Register(string name, string email, string password);
        public Result Logout();
        public List<Card> GetUserCards(int id);
        public List<User> GetAllusers();
        public Result DeActivateUser(string email);
        public Result ChangeUserPass(string email, string newpass);
    }
}
