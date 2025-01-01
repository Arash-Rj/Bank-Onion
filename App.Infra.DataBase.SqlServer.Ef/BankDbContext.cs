
using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.Bnak.BankTransactions.Entities;
using Src.Domain.Core.Bnak.Cards.Entities;
using Src.Domain.Core.Bnak.Users.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataBase.SqlServer.Ef
{
    public class BankDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionStrings.Connection1);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TransactionConfig());

        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<BankTransaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
