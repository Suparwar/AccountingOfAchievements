﻿// <auto-generated />
using System;
using AccountingOfAchievements.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccountingOfAchievements.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231130122045_second")]
    partial class second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AccountingOfAchievements.Domain.Model.Achievement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfReceiving")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IssuedFromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PortfolioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IssuedFromId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("AccountingOfAchievements.Domain.Model.Portfolio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("AccountingOfAchievements.Domain.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("AccountingOfAchievements.Domain.Model.Achievement", b =>
                {
                    b.HasOne("AccountingOfAchievements.Domain.Organization", "IssuedFrom")
                        .WithMany("Achievements")
                        .HasForeignKey("IssuedFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AccountingOfAchievements.Domain.Model.Portfolio", "Portfolio")
                        .WithMany("Achievements")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IssuedFrom");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("AccountingOfAchievements.Domain.Model.Portfolio", b =>
                {
                    b.Navigation("Achievements");
                });

            modelBuilder.Entity("AccountingOfAchievements.Domain.Organization", b =>
                {
                    b.Navigation("Achievements");
                });
#pragma warning restore 612, 618
        }
    }
}
