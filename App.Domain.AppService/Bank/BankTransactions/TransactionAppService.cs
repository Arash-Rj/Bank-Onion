using App.Domain.Service.Bank.BankTransactions;

using Src.Domain.Core.Bnak.BankTransactions.AppService;
using Src.Domain.Core.Bnak.BankTransactions.Entities;
using Src.Domain.Core.Bnak.BankTransactions.Service;
using Src.Domain.Core.Bnak.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Bank.BankTransactions
{
    public class TransactionAppService : ITransactionAppService
    {
        ITransactionService transactionService = new TransactionService();
        public List<BankTransaction> CardTransactionList(string cardbnumber)
        {
            return transactionService.CardTransactionList(cardbnumber);
        }

        public Result Transfer(string sourcecard, string destinationcard, float amount)
        {
            return transactionService.Transfer(sourcecard, destinationcard, amount);
        }
    }
}
