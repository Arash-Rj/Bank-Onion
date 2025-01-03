using App.Domain.AppService.Bank.BankTransactions;
using App.Domain.AppService.Bank.Cards;
using App.Domain.AppService.Bank.Users;
using App.Domain.Service.Bank.BankTransactions;
using App.Domain.Service.Bank.Cards;
using App.Domain.Service.Bank.Users;
using App.Infra.DataAccess.Repos.Ef.Bank.Cards;
using App.Infra.DataAccess.Repos.Ef.Bank.Transactions;
using App.Infra.DataAccess.Repos.Ef.Bank.Users;
using Src.Domain.Core.Bnak.BankTransactions.AppService;
using Src.Domain.Core.Bnak.BankTransactions.Repository;
using Src.Domain.Core.Bnak.BankTransactions.Service;
using Src.Domain.Core.Bnak.Cards.AppService;
using Src.Domain.Core.Bnak.Cards.Repository;
using Src.Domain.Core.Bnak.Cards.Service;
using Src.Domain.Core.Bnak.Users.AppService;
using Src.Domain.Core.Bnak.Users.Repository;
using Src.Domain.Core.Bnak.Users.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICardAppService, CardAppService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionAppService, TransactionAppService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
