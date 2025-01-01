
using Src.Domain.Core.Bnak.BankTransactions.Entities;
using Src.Domain.Core.Bnak.Cards.Entities;
using Src.Domain.Core.Bnak.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Bnak.Cards.Repository
{
    public interface ICardRepository
    {
        Card GetCardByNo(string cardnumber);
        public float GetCardAmount(string cardnumber);
        public Result DoesCardExists(string cardnumber, string password);
        public bool IsCardNumberValid(string cardnumber);
        //public bool IsCardPasswordValid(string currentpassword);
        public bool IsCardActive(string cardnumber);
        public float? GetCardBalance(string cardnumber);
        public void Update(Card card);
        
    }
}
