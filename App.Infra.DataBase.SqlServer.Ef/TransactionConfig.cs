
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Src.Domain.Core.Bnak.BankTransactions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataBase.SqlServer.Ef
{
    public class TransactionConfig: IEntityTypeConfiguration<BankTransaction>
    {
        public void Configure(EntityTypeBuilder<BankTransaction> builder)
        {
            builder
         .HasOne(t => t.SourceCard)
         .WithMany(c => c.WithdrawTransactions)
         .HasForeignKey(t => t.SourceCardNumber)
         .OnDelete(DeleteBehavior.Restrict);

            builder
        .HasOne(t => t.DestinationCard)
        .WithMany(c => c.DepositTransactions)
        .HasForeignKey(t => t.DestinationCardNumber)
        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
