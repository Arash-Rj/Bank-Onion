using App.Infra.DataAccess.Repos.Ef.Bank.Cards;
using App.Infra.DataBase.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.Bnak.BankTransactions.Entities;
using Src.Domain.Core.Bnak.BankTransactions.Repository;
using Src.Domain.Core.Bnak.Cards.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repos.Ef.Bank.Transactions
{
    public class TransactionRepository: ITransactionRepository
    {
        private BankDbContext BankDbContext = new BankDbContext();
        private readonly ICardRepository cardRepository = new CardRepository();

        public bool Transfer(string sourcecard, string destinationcard, float amount)
        {
            BankTransaction transaction = new BankTransaction(destinationcard, sourcecard, amount);
            var destncard = cardRepository.GetCardByNo(destinationcard);
            var sourccard = cardRepository.GetCardByNo(sourcecard);
            float feeamount = 0;
            if (amount > 1000)
            {
                feeamount = (float)(0.015 * amount + amount);
            }
            else
            {
                feeamount = (float)(0.005 * amount + amount);
            }
            sourccard.Balance -= feeamount;
            try
            {
                destncard.Balance += amount;
            }
            catch (Exception ex)
            {
                sourccard.Balance += amount;
                throw new Exception();
            }
            BankDbContext.Cards.Update(destncard);
            BankDbContext.Cards.Update(sourccard);
            BankDbContext.Transactions.Add(transaction);
            BankDbContext.SaveChanges();
            return true;
        }
        public float TransactionAmountInDay(string cardnumber)
        {
            var transactions = BankDbContext.Transactions.Where(t => t.SourceCardNumber == cardnumber && t.TransactionDate.Date == DateTime.Now.Date).ToList();
            float amount = 0;
            transactions.ForEach(t => amount += t.Amount);
            return amount;
        }
        public List<BankTransaction> GetCardTransactions(string cardnumber)
        {
            return BankDbContext.Transactions.AsNoTracking().Where(t => t.SourceCardNumber == cardnumber || t.DestinationCardNumber == cardnumber).ToList();
        }
    }
}
