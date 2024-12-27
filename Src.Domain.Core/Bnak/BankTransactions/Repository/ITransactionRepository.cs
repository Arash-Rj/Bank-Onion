using Src.Domain.Core.Bnak.BankTransactions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Bnak.BankTransactions.Repository
{
    public interface ITransactionRepository
    {
        bool Transfer(string sourcecard, string destinationcard, float amount);
        List<BankTransaction> GetCardTransactions(string cardnumber);
        public float TransactionAmountInDay(string cardnumber);
    }
}
