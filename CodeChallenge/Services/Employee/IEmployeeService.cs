using CodeChallenge.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Web.Services
{
    public interface IEmployeeService
    {
        Task<ResultModel> GetAll();
        Task<ResultModel> GetById(int EmployeeId);
        Task<ResultModel> Add(EmployeeModel model);
        Task<ResultModel> Edit(EmployeeModel model);
        Task<ResultModel> Delete(int EmployeeId);
    }
}
