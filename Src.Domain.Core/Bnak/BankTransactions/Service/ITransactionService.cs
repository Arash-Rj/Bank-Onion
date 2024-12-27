
using Src.Domain.Core.Bnak.BankTransactions.Entities;
using Src.Domain.Core.Bnak.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Bnak.BankTransactions.Service
{
    public interface ITransactionService
    {
        Result Transfer(string sourcecard, string destinationcard, float amount);
        public List<BankTransaction> CardTransactionList(string cardbnumber);
    }
}
