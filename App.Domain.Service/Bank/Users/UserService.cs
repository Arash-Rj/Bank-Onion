
using App.Infra.DataAccess.Repos.Ef.Bank.Cards;
using App.Infra.DataAccess.Repos.Ef.Bank.Users;
using App.Infra.DataBase.SqlServer.Ef;
using Src.Domain.Core.Bnak.Cards.Entities;
using Src.Domain.Core.Bnak.ResultModel;
using Src.Domain.Core.Bnak.Users.Entities;
using Src.Domain.Core.Bnak.Users.Repository;
using Src.Domain.Core.Bnak.Users.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service.Bank.Users
{
    public class UserService: IUserService
    {
        IUserRepository _userRepository = new UserRepository();

        public Result ChangeUserPass(string email, string newpass)
        {
           var user =  _userRepository.GetUserByEmail(email);
            if(user == null)
            {
                return new Result(false, "User not found!");
            }
            user.Password = newpass;
            _userRepository.Update(user);
            return new Result(true, "Password successfully changed.");
        }

        public Result DeActivateUser(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return new Result(false, "The User Email is wrong");
            }
            user.IsActive = false;
            _userRepository.Update(user);
            return new Result(true, "You are deactivated.");
        }

        public List<User>? GetAllusers()
        {
            return _userRepository.GetAll();
        }

        public List<Card>? GetUserCards(int id)
        {
          return  _userRepository.GetCards(id);
        }

        public Result Login(string email, string password)
        {
            bool exist = _userRepository.DoesUserExist(email, password);
            if (exist)
            {
                var user = _userRepository.GetUserByEmail(email);
                OnlineUser.user = user;
                return new Result(true, "User Logged in successfully.");
            }
            return new Result(false, "User was not found please try again.");
        }

        public Result Logout()
        {
            OnlineUser.user = null;
            return new Result(true);
        }

        public Result Register(string name, string email, string password)
        {
            if (name == "" || email == "" || password == "")
            {
                return new Result(false, "Feilds can not be empty. try again.");
            }
            if (_userRepository.DoesUserExist(email, password))
            {
                return new Result(false, "The User Already exists.");
            }
            if (_userRepository.AddUser(name, email, password))
            {
                return new Result(true, "User Registered successfully.");
            }
            return new Result(false, "User could not be registered.");
        }
    }
}
