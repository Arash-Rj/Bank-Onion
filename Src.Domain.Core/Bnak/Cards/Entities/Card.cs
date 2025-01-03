﻿using Src.Domain.Core.Bnak.BankTransactions.Entities;
using Src.Domain.Core.Bnak.Users.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Bnak.Cards.Entities
{
    public class Card
    {
        [Key]
        public string CardNumber { get; set; }
        public string password { get; set; }
        public string HolderName { get; set; }
        public bool IsActive { get; set; }
        public float Balance { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<BankTransaction> DepositTransactions { get; set; }
        public List<BankTransaction> WithdrawTransactions { get; set; }
        public Card()
        {

        }
    }
}
