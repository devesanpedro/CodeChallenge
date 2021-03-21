using CodeChallenge.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Service.Services
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
