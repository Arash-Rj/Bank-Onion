using App.Domain.Service.Bank.Users;
using Src.Domain.Core.Bnak.Cards.Entities;
using Src.Domain.Core.Bnak.ResultModel;
using Src.Domain.Core.Bnak.Users.AppService;
using Src.Domain.Core.Bnak.Users.Entities;
using Src.Domain.Core.Bnak.Users.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Bank.Users
{
    public class UserAppService : IUserAppService
    {
        IUserService userService = new UserService();

        public Result ChangeUserPass(string email, string newpass)
        {
           return userService.ChangeUserPass
                (email, newpass);
        }

        public Result DeActivateUser(string email)
        {
          return userService.DeActivateUser(email);
        }

        public List<User> GetAllusers()
        {
           var users =  userService.GetAllusers();
            if(users == null)
            {
                throw new NullReferenceException("NO users found!");
            }
            return users;
        }

        public List<Card> GetUserCards(int id)
        {
           var cards =  userService.GetUserCards(id);
            if (cards == null)
            {
                throw new NullReferenceException();
            }
            return cards;
        }

        public Result Login(string email, string password)
        {
           return userService.Login(email, password);
        }

        public Result Logout()
        {
            return userService.Logout();
        }

        public Result Register(string name, string email, string password)
        {
           return userService.Register(name, email, password);
        }
    }
}
