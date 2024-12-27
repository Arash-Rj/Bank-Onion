
using App.Infra.DataBase.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.Bnak.Cards.Entities;
using Src.Domain.Core.Bnak.Cards.Repository;
using Src.Domain.Core.Bnak.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repos.Ef.Bank.Cards
{
    public class CardRepository: ICardRepository
    {
        private BankDbContext BankDbContext = new BankDbContext();

        public Card? GetCardByNo(string cardnumber)
        {
            return BankDbContext.Cards.FirstOrDefault(c => c.CardNumber == cardnumber);
        }
        public float GetCardAmount(string cardnumber)
        {
            var card = BankDbContext.Cards.SingleOrDefault(c => c.CardNumber.Equals(cardnumber));
            return card.Balance;
        }
        public Result DoesCardExists(string cardnumber, string password)
        {
            var doesexists = BankDbContext.Cards.Any(c => c.CardNumber == cardnumber && c.password == password);
            if (doesexists)
            {
                return new Result(doesexists);
            }
            return new Result(false, "The card does not exists.");
        }

        public bool IsCardNumberValid(string cardnumber)
        {
            return BankDbContext.Cards.Any(c => c.CardNumber == cardnumber);
        }

        public bool IsCardActive(string cardnumber)
        {
            return BankDbContext.Cards.SingleOrDefault(c => c.CardNumber == cardnumber).IsActive;
        }

        public float? GetCardBalance(string cardnumber)
        {
            var card = BankDbContext.Cards.AsNoTracking().FirstOrDefault(c => c.CardNumber.Equals(cardnumber));
            var balance = card.Balance;
            return balance;
        }

        public void Update(Card card)
        {
            BankDbContext.Update(card);
            BankDbContext.SaveChanges();
        }

        //public bool IsCardPasswordValid(string currentpassword)
        //{
        //    return BankDbContext.Cards.Any(c => c.password == currentpassword);
        //}

    }
}
