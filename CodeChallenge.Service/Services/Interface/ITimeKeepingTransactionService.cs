using CodeChallenge.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Service.Services
{
    public interface ITimeKeepingTransactionService
    {
        Task<ResultModel> GetAllByEmployeeId(int EmployeeId);
        Task<ResultModel> GetByEmployeeIdTransactionDateTime(int EmployeeId, DateTime TransactionDateTime);
        Task<ResultModel> Add(TimekeepingTransactionModel model);
    }
}
