using CodeChallenge.Persistence.Database;
using CodeChallenge.Persistence.Entities;
using CodeChallenge.Service.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Service.Services
{
    public class TimeKeepingTransactionService : ITimeKeepingTransactionService
    {
        private readonly ApplicationDbContext _dbContext;

        public TimeKeepingTransactionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultModel> Add(TimekeepingTransactionModel model)
        {
            using (_dbContext)
            {
                using (var tranScope = await _dbContext.Database.BeginTransactionAsync())
                {
                    
                    TimekeepingTransaction timekeepingTransaction;

                    _dbContext.TimekeepingTransactions.Add(timekeepingTransaction = new TimekeepingTransaction
                    {
                       EmployeeId = model.EmployeeId,
                       TransactionTypeId = model.TransactionTypeId,
                       TransactionDateTime = DateTime.Now
                    });

                    await _dbContext.SaveChangesAsync();

                    tranScope.Commit();

                    return new ResultModel
                    {
                        IsSuccessful = true,
                        Data = timekeepingTransaction,
                        Message = "Transaction successfully created!"
                    };

                }
            }
        }

        public async Task<ResultModel> GetAllByEmployeeId(int EmployeeId)
        {
            using (_dbContext)
            {
                var timekeepingTransactions = await _dbContext.TimekeepingTransactions.Where(i => i.EmployeeId == EmployeeId).ToListAsync();

                var timekeepingTransactionModels = JsonConvert.DeserializeObject<List<TimekeepingTransactionModel>>(JsonConvert.SerializeObject(timekeepingTransactions));

                foreach (var item in timekeepingTransactionModels)
                {
                    item.TransactionTypeName = _dbContext.TransactionTypes.FirstOrDefault(i => i.Id == item.TransactionTypeId).Name;
                }

                return new ResultModel
                {
                    IsSuccessful = true,
                    Data = timekeepingTransactionModels,
                };
            }
        }

        public async Task<ResultModel> GetByEmployeeIdTransactionDateTime(int EmployeeId, DateTime TransactionDateTime)
        {
            using (_dbContext)
            {
                var timekeepingTransactions = await _dbContext.TimekeepingTransactions.Where(i => i.EmployeeId == EmployeeId && i.TransactionDateTime == TransactionDateTime).ToListAsync();

                var timekeepingTransactionModels = JsonConvert.DeserializeObject<List<TimekeepingTransactionModel>>(JsonConvert.SerializeObject(timekeepingTransactions));

                foreach(var item in timekeepingTransactionModels)
                {
                    item.TransactionTypeName = _dbContext.TransactionTypes.FirstOrDefault(i => i.Id == item.TransactionTypeId).Name;
                }

                return new ResultModel
                {
                    IsSuccessful = true,
                    Data = timekeepingTransactionModels,
                };
            }
        }
    }
}
