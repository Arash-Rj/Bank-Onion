using App.Domain.AppService.Bank.BankTransactions;
using App.Domain.AppService.Bank.Cards;
using App.Domain.AppService.Bank.Users;
using App.Domain.Service.Bank.Cards;
using App.Domain.Service.Bank.Users;
using App.Endpoints.MVC.Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.Bnak.ResultModel;
using Src.Domain.Core.Bnak.Users.Entities;
using Src.Domain.Core.Bnak.Users.Service;

namespace App.Endpoints.MVC.Bank.Controllers
{
    public class UserController : Controller
    {
        UserAppService userAppService = new UserAppService();
        TransactionAppService transactionAppService = new TransactionAppService();
        CardAppService cardAppService = new CardAppService();
        public IActionResult Index()
        {
            var users = userAppService.GetAllusers();
            return View(users);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string name, string email, string password, int age)
        {

            var isdone = userAppService.Register(name, email, password);
            return RedirectToAction("Index");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            
            var isdone = userAppService.Login(email, password);
            if(!isdone.IsDone)
            {
                LoginCount.loginCount++;
                if (LoginCount.loginCount >= 3)
                {
                   var isdeactivateed = userAppService.DeActivateUser(email);
                    if(isdeactivateed.IsDone)
                    {
                        ViewBag.LoginCountErrorMessage = "You have entered wrong passwrod 3 times, you are now deactivated.";
                        LoginCount.loginCount = 0;
                    }
                    else
                    {
                        ViewBag.EmailError = isdeactivateed.Message;
                    }
                }
                ViewBag.LoginError = isdone.Message;
                return View();
            }
            LoginCount.loginCount = 0;
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Transfer()
        {
            return View(OnlineUser.user);
        }
        [HttpPost]
        public IActionResult Transfer(string sourcecard,string destcard,float amount,int code)
        {
            var isvalid = cardAppService.IsCodeValid(code);

            if(!isvalid.IsDone)
            {
                TempData["CodeErrorMessage"] = isvalid.Message;
                return RedirectToAction("Transfer");
            }
            var isdone = transactionAppService.Transfer(sourcecard, destcard, amount);
            return RedirectToAction("Transaction" , "Card", new { cardnumber =  sourcecard});
        }
        public IActionResult Logout()
        {
            userAppService.Logout();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(string email,string newpass)
        {
            var isdone = userAppService.ChangeUserPass(email, newpass);
            if (!isdone.IsDone)
            {
                ViewBag.Error = isdone.Message;
                return View();
            }
            TempData["SuccessMessage"] = isdone.Message;
            return RedirectToAction("Index", "Home");
        }
        public IActionResult RandomCode()
        {
            cardAppService.GenerateRandomCode();
            TempData["RandomCodeMessage"] = $"!Note: The random code is only valid for 50 secondes. ";
            return RedirectToAction("Transfer");
        }
    }
}
