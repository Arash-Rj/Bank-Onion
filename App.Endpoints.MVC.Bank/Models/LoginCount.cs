using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace App.Endpoints.MVC.Bank.Models
{
    public static class LoginCount
    {
        public static int loginCount { get; set; } = 0;
    }
}
