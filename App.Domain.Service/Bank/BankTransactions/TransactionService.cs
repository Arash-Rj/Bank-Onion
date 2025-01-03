﻿using App.Domain.Service.Bank.Cards;

using App.Infra.DataAccess.Repos.Ef.Bank.Transactions;
using Src.Domain.Core.Bnak.BankTransactions.Entities;
using Src.Domain.Core.Bnak.BankTransactions.Repository;
using Src.Domain.Core.Bnak.BankTransactions.Service;
using Src.Domain.Core.Bnak.Cards.Service;
using Src.Domain.Core.Bnak.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service.Bank.BankTransactions
{
    public class TransactionService: ITransactionService
    {
        private readonly ITransactionRepository Transactionrepository;
        private readonly ICardService cardservice;
        public TransactionService(ITransactionRepository transactionRepository, ICardService cardService)
        {
            Transactionrepository = transactionRepository;
            cardservice = cardService;
        }
        public Result Transfer(string sourcecard, string destinationcard, float amount)
        {
            var transactionamount = Transactionrepository.TransactionAmountInDay(sourcecard);
            if (transactionamount >= 1250)
            {
                return new Result(false, " Transfer limit has been exceeded.");
            }
            if (transactionamount + amount > 1250)
            {
                return new Result(false, $"The Transfer limit will be  exceeded.Entered amonut must be less than {1250 - transactionamount}");
            }
            if (amount < 0)
            {
                return new Result(false, "The transfer amount must be greater than zero.");
            }
            var isdestvalid = cardservice.IsCardNumberValid(destinationcard);
            if (isdestvalid.IsDone)
            {
                var isenough = cardservice.IsAmountenough(sourcecard, destinationcard, amount);
                if (isenough.IsDone)
                {
                    var isdone = false;
                    try
                    {
                        isdone = Transactionrepository.Transfer(sourcecard, destinationcard, amount);
                    }
                    catch (Exception ex)
                    {
                        return new Result(false, "An Error accured during transaction.");
                    }
                    return new Result(isdone);
                }
                return new Result(false, isenough.Message);
            }
            return isdestvalid;
        }
        public List<BankTransaction> CardTransactionList(string cardbnumber)
        {
            return Transactionrepository.GetCardTransactions(cardbnumber);
        }
    }
}
