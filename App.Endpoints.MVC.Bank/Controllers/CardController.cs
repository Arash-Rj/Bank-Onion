using App.Domain.AppService.Bank.BankTransactions;
using App.Domain.AppService.Bank.Cards;
using App.Domain.AppService.Bank.Users;
using App.Endpoints.MVC.Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.Bnak.BankTransactions.AppService;
using Src.Domain.Core.Bnak.Cards.AppService;
using Src.Domain.Core.Bnak.Cards.Entities;
using Src.Domain.Core.Bnak.Users.AppService;
using Src.Domain.Core.Bnak.Users.Entities;

namespace App.Endpoints.MVC.Bank.Controllers
{
    public class CardController : Controller
    {
        private readonly IUserAppService userAppService;
        private readonly ITransactionAppService transactionAppService;
        private readonly ICardAppService cardAppService;
        public CardController(IUserAppService userAppService,ICardAppService cardAppService,ITransactionAppService transactionAppService)
        {
            this.userAppService = userAppService;
            this.transactionAppService = transactionAppService;
            this.cardAppService = cardAppService;
        }
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
