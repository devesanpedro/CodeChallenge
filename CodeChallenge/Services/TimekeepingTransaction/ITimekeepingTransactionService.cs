using CodeChallenge.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Web.Services
{
    public interface ITimekeepingTransactionService
    {
        Task<ResultModel> GetAllByEmployeeId(int EmployeeId);
        Task<ResultModel> GetByEmployeeIdTransactionDateTime(int EmployeeId, DateTime TransactionDateTime);
        Task<ResultModel> Add(TimekeepingTransactionModel model);
    }
}
