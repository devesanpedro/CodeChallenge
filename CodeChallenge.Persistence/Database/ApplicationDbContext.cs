using CodeChallenge.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<TimekeepingTransaction> TimekeepingTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed TransactionType
            modelBuilder.Entity<TransactionType>().HasData(new TransactionType { Id = 1, Name = "IN" });
            modelBuilder.Entity<TransactionType>().HasData(new TransactionType { Id = 2, Name = "OUT" });

            //Seed Employee
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 1, FirstName = "Elmer", LastName = "San Pedro", Gender = Enums.Gender.Male, DateHired = DateTime.Now });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 2, FirstName = "Bill", LastName = "Gate", Gender = Enums.Gender.Male, DateHired = DateTime.Now });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 3, FirstName = "Sarah", LastName = "McGregor", Gender = Enums.Gender.Female, DateHired = DateTime.Now });
        }
    }
}
