
using Src.Domain.Core.Bnak.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Bnak.Users.AppService
{
    public interface IUserAppService
    {
        public Result Login(string email, string password);
        public Result Register(string name, string email, string password);
        public Result Logout();
    }
}
