﻿
using App.Infra.DataAccess.Repos.Ef.Bank.Cards;
using App.Infra.DataBase.SqlServer.Ef;
using Newtonsoft.Json;
using Src.Domain.Core.Bnak.BankTransactions.Entities;
using Src.Domain.Core.Bnak.Cards.Repository;
using Src.Domain.Core.Bnak.Cards.Service;
using Src.Domain.Core.Bnak.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service.Bank.Cards
{
    public class CardService: ICardService
    {
        private readonly ICardRepository CardRepository ;
        public CardService(ICardRepository cardRepository)
        {
            CardRepository = cardRepository ;
        }
        private string path = @"D:/programming/BAnk/Bank/Bank/Codes.txt";
        public Result IsAmountenough(string sourcecardnumber, string destinationcardnumber, float amount)
        {
            var sourcecardamount = CardRepository.GetCardAmount(sourcecardnumber);
            if (sourcecardamount > amount)
            {
                return new Result(true);
            }
            return new Result(false, "The Source card Balance is not enough.");
        }

        public Result IsCardValid(string cardnumber, string password)
        {
            if (cardnumber.Length == 16)
            {
                var doesexists = CardRepository.DoesCardExists(cardnumber, password);
                if (doesexists.IsDone)
                {
                    var isactive = CardRepository.IsCardActive(cardnumber);
                    if (!isactive)
                    {
                        return new Result(false, "Card is not active.");
                    }
                    return new Result(true);
                }
                return new Result(false, doesexists.Message);
            }
            return new Result(false, "The card number must be 16 digits.");
        }
        public Result IsCardNumberValid(string cardnumber)
        {
            if (cardnumber.Length == 16)
            {
                var doesexists = CardRepository.IsCardNumberValid(cardnumber);
                if (doesexists)
                {
                    return new Result(true);
                }
                return new Result(false, "The Card number is not valid.");
            }
            return new Result(false, "The card number must be 16 digits.");
        }
        public Result DeActivateCard(string cardnumber)
        {
            var card = CardRepository.GetCardByNo(cardnumber);
            if (card == null)
            {
                return new Result(false, "The card number is wrong");
            }
            card.IsActive = false;
            CardRepository.Update(card);
            return new Result(true, "Your card is deactivated.");
        }

        public Result CardBalance(string cardnumber)
        {
            var isvalid = IsCardNumberValid(cardnumber);
            if (isvalid.IsDone)
            {
                var cardbalance = CardRepository.GetCardBalance(cardnumber);

                return new Result(true, $"Your card balance is: {cardbalance}");
            }
            return isvalid;
        }

        public Result ChangecardPass(string cardnumber, string currentpassword, string newpassword)
        {
            var isvalid = CardRepository.DoesCardExists(cardnumber, currentpassword);
            if (isvalid.IsDone)
            {
                var card = CardRepository.GetCardByNo(cardnumber);
                card.password = newpassword;
                CardRepository.Update(card);
                return new Result(true, "Password changed successfully.");
            }
            return new Result(false, "The entered password is wrong.Please try again.");
        }

        public Result GetCardHoldername(string cardnumber)
        {
            var name = CardRepository.GetCardByNo(cardnumber).HolderName;
            if (name == null)
            {
                return new Result(false, "Could not find holder's name.");

            }
            return new Result(true, $"Reciever's name: {name}");
        }

        public int GenerateRandomCode()
        {
            Random random = new Random();
            int randomcode = random.Next(1000, 10000);
            string resullt = JsonConvert.SerializeObject(randomcode);
            File.WriteAllText(path, resullt);
            return randomcode;
        }
    }
}
