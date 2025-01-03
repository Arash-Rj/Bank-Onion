﻿using App.Infra.DataBase.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.Bnak.Cards.Entities;
using Src.Domain.Core.Bnak.Users.Entities;
using Src.Domain.Core.Bnak.Users.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repos.Ef.Bank.Users
{
    public class UserRepository: IUserRepository
    {
        private BankDbContext BankDbContext = new BankDbContext();
        public bool AddUser(string name, string eamil, string password)
        {
            var user = new User(name, eamil, password);
            try
            {
                BankDbContext.Users.Add(user);
                BankDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool DoesUserExist(string eamil, string password)
        {
            return BankDbContext.Users.Any(u => u.Email == eamil && u.Password == password);
        }

        public List<User>? GetAll()
        {
            return BankDbContext.Users.ToList();
        }

        public List<Card>? GetCards(int id)
        {
            return BankDbContext.Cards.Where(c => c.UserId == id).ToList();
        }

        public User GetUserByEmail(string email)
        {
            return BankDbContext.Users.AsNoTracking().Include(u => u.Cards).Single(u => u.Email == email);
        }

        public void Update(User user)
        {
            BankDbContext.Update(user);
            BankDbContext.SaveChanges();
        }
    }
}
