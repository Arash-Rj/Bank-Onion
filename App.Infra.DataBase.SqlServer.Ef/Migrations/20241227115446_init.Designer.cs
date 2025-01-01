﻿// <auto-generated />
using System;
using App.Infra.DataBase.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Infra.DataBase.SqlServer.Ef.Migrations
{
    [DbContext(typeof(BankDbContext))]
    [Migration("20241227115446_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Src.Domain.Core.Bnak.BankTransactions.Entities.BankTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("DestinationCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SourceCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DestinationCardNumber");

                    b.HasIndex("SourceCardNumber");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Src.Domain.Core.Bnak.Cards.Entities.Card", b =>
                {
                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("HolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardNumber");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Src.Domain.Core.Bnak.Users.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Src.Domain.Core.Bnak.BankTransactions.Entities.BankTransaction", b =>
                {
                    b.HasOne("Src.Domain.Core.Bnak.Cards.Entities.Card", "DestinationCard")
                        .WithMany("DepositTransactions")
                        .HasForeignKey("DestinationCardNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Src.Domain.Core.Bnak.Cards.Entities.Card", "SourceCard")
                        .WithMany("WithdrawTransactions")
                        .HasForeignKey("SourceCardNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DestinationCard");

                    b.Navigation("SourceCard");
                });

            modelBuilder.Entity("Src.Domain.Core.Bnak.Cards.Entities.Card", b =>
                {
                    b.HasOne("Src.Domain.Core.Bnak.Users.Entities.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Src.Domain.Core.Bnak.Cards.Entities.Card", b =>
                {
                    b.Navigation("DepositTransactions");

                    b.Navigation("WithdrawTransactions");
                });

            modelBuilder.Entity("Src.Domain.Core.Bnak.Users.Entities.User", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
