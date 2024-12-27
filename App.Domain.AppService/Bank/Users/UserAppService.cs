using App.Domain.Service.Bank.Users;
using Src.Domain.Core.Bnak.ResultModel;
using Src.Domain.Core.Bnak.Users.AppService;
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
