﻿// <auto-generated />
using System;
using CodeChallenge.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeChallenge.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210319105353_Added_EmployeeSeeder")]
    partial class Added_EmployeeSeeder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeChallenge.Persistence.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateHired")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateHired = new DateTime(2021, 3, 19, 18, 53, 53, 338, DateTimeKind.Local).AddTicks(5671),
                            FirstName = "Elmer",
                            Gender = 1,
                            LastName = "San Pedro"
                        },
                        new
                        {
                            Id = 2,
                            DateHired = new DateTime(2021, 3, 19, 18, 53, 53, 339, DateTimeKind.Local).AddTicks(3432),
                            FirstName = "Bill",
                            Gender = 1,
                            LastName = "Gate"
                        },
                        new
                        {
                            Id = 3,
                            DateHired = new DateTime(2021, 3, 19, 18, 53, 53, 339, DateTimeKind.Local).AddTicks(3500),
                            FirstName = "Sarah",
                            Gender = 2,
                            LastName = "McGregor"
                        });
                });

            modelBuilder.Entity("CodeChallenge.Persistence.Entities.TimekeepingTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TimekeepingTransactions");
                });

            modelBuilder.Entity("CodeChallenge.Persistence.Entities.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "IN"
                        },
                        new
                        {
                            Id = 2,
                            Name = "OUT"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}