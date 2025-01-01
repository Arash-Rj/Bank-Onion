using App.Domain.AppService.Bank.BankTransactions;
using App.Domain.AppService.Bank.Cards;
using App.Domain.AppService.Bank.Users;
using App.Endpoints.MVC.Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.Bnak.Cards.Entities;
using Src.Domain.Core.Bnak.Users.Entities;

namespace App.Endpoints.MVC.Bank.Controllers
{
    public class CardController : Controller
    {
        UserAppService userAppService = new UserAppService();
        TransactionAppService transactionAppService = new TransactionAppService();
        CardAppService cardAppService = new CardAppService();
        public IActionResult Index()
        {
            var cards = userAppService.GetUserCards(OnlineUser.user.Id);
            return View(cards);
        }
        public IActionResult Transaction(string cardnumber)
        {
            return View(transactionAppService.CardTransactionList(cardnumber));
        }
        public IActionResult ChangePassword()
        {
            return View(OnlineUser.user);
        }
        [HttpPost]
        public IActionResult ChangePassword(string cardnumber,string newpass,string currentpass)
        {
           var res =  cardAppService.ChangecardPass(cardnumber, currentpass, newpass);
            return View("Home");
        }
    }
}
