using Src.Domain.Core.Bnak.BankTransactions.Entities;
using Src.Domain.Core.Bnak.Users.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace App.Endpoints.MVC.Bank.Models
{
    public class CardModel
    {
        [Key]
        public string CardNumber { get; set; }
        public string password { get; set; }
        public string HolderName { get; set; }
        public bool IsActive { get; set; }
        public float Balance { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public List<BankTransactionModel> DepositTransactions { get; set; }
        public List<BankTransactionModel> WithdrawTransactions { get; set; }
        public CardModel()
        {

        }
    }
}
