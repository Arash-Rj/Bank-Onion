using Src.Domain.Core.Bnak.Cards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Src.Domain.Core.Bnak.BankTransactions.Entities
{
    public class BankTransaction
    {

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public float Amount { get; set; }

        public string SourceCardNumber { get; set; }
        public Card SourceCard { get; set; }

        public string DestinationCardNumber { get; set; }
        public Card DestinationCard { get; set; }
        public BankTransaction(string destinationcardno, string sourcecardno, float amount)
        {
            TransactionDate = DateTime.Now;
            Amount = amount;
            SourceCardNumber = sourcecardno;
            DestinationCardNumber = destinationcardno;

        }
        public override string ToString()
        {
            return $"Source Card: {SourceCardNumber} || Destination Card: {DestinationCardNumber} || Transaction Date: {TransactionDate} || Amount: {Amount}";
        }
        public BankTransaction() { }
    }
}