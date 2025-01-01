
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace App.Endpoints.MVC.Bank.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<CardModel> Cards { get; set; }
        public UserModel() { }
        public UserModel(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
