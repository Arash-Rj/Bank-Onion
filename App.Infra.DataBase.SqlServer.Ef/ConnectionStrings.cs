using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataBase.SqlServer.Ef
{
    public class ConnectionStrings
    {
        public static string Connection1 { get; set; }

        static ConnectionStrings()
        {
            Connection1 = @"Data Source=DESKTOP-7648UU0\SQLEXPRESS; Initial Catalog=Bank-Onion; User Id=sa; Password=123456; TrustServerCertificate=True;";
        }
    }
}
