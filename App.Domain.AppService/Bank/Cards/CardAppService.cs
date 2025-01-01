using App.Domain.Service.Bank.Cards;
using Src.Domain.Core.Bnak.BankTransactions.Entities;
using Src.Domain.Core.Bnak.Cards.AppService;
using Src.Domain.Core.Bnak.Cards.Service;
using Src.Domain.Core.Bnak.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Bank.Cards
{
    public class CardAppService : ICardAppService
    {
        ICardService cardService = new CardService();
        static Dictionary<int, DateTime> Codes = new Dictionary<int, DateTime>();
        public Result CardBalance(string cardnumber)
        {
            return cardService.CardBalance(cardnumber);
        }

        public Result ChangecardPass(string cardnumber, string currentpassword, string newpassword)
        {
            return cardService.ChangecardPass(cardnumber, currentpassword, newpassword);
        }

        public Result DeActivateCard(string cardnumber)
        {
            return cardService.DeActivateCard(cardnumber);
        }

        public int GenerateRandomCode()
        {
            var randomcode = cardService.GenerateRandomCode();
            Codes[randomcode] = DateTime.Now.AddSeconds(50);
            return randomcode;
        }

        public Result GetCardHoldername(string cardnumber)
        {
            return cardService.GetCardHoldername(cardnumber);
        }
        public Result IsAmountenough(string sourcecardnumber, string destinationcardnumber, float amount)
        {
            return cardService.IsAmountenough(sourcecardnumber, destinationcardnumber, amount);
        }

        public Result IsCardNumberValid(string cardnumber)
        {
            return cardService.IsCardNumberValid(cardnumber);
        }

        public Result IsCardValid(string cardnumber, string password)
        {
            return cardService.IsCardValid(cardnumber, password);
        }

        public Result IsCodeValid(int code)
        {
            if (Codes.ContainsKey(code) && Codes[code] > DateTime.Now)
            {
                return new Result(true);
            }
            if (Codes.ContainsKey(code) && Codes[code] < DateTime.Now)
            {
                Codes.Remove(code);
                return new Result(false, "The Code has expired.");
            }
            return new Result(false, "The Entered code is wrong.");
        }
    }
}
