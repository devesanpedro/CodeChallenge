using CodeChallenge.Persistence.Database;
using CodeChallenge.Persistence.Entities;
using CodeChallenge.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CodeChallenge.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        protected ApplicationDbContext _dbContext;

        public EmployeeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultModel> Add(EmployeeModel model)
        {
            using (_dbContext)
            {
                Employee employee;

                using (var tranScope = await _dbContext.Database.BeginTransactionAsync())
                {
                    var isEmployeeExist = _dbContext.Employees.Any(i => i.FirstName == model.FirstName && i.LastName == model.LastName);

                    if (!isEmployeeExist)
                    {

                        _dbContext.Employees.Add(employee = new Employee {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Gender = model.Gender,
                            DateHired = model.DateHired
                        });

                        await _dbContext.SaveChangesAsync();

                        var result =  new ResultModel
                        {
                            IsSuccessful = true,
                            Data = employee,
                            Message = "Employee successfully created!"
                        };

                        tranScope.Commit();

                        return result;

                    } else
                    {
                        return new ResultModel
                        {
                            IsSuccessful = false,
                            Message = "Employee name already exist!"
                        };
                    }
            }
        }
        }

        public async Task<ResultModel> Delete(int EmployeeId)
        {
            using (_dbContext)
            {
                using (var tranScope = await _dbContext.Database.BeginTransactionAsync())
                {
                    var employee = await _dbContext.Employees.FirstOrDefaultAsync(i => i.Id == EmployeeId);

                    if (employee != null)
                    {
                        _dbContext.Remove(employee);

                        await _dbContext.SaveChangesAsync();

                        var result = new ResultModel
                        {
                            IsSuccessful = true,
                            Data = employee,
                            Message = "Employee successfully deleted!"
                        };

                        tranScope.Commit();

                        return result;

                    }
                    else
                    {
                        return new ResultModel
                        {
                            IsSuccessful = false,
                            Message = "Employee doesn't exist!"
                        };
                    }
                }
            }
        }

        public async Task<ResultModel> Edit(EmployeeModel model)
        {
            using (_dbContext)
            {
                using (var tranScope = await _dbContext.Database.BeginTransactionAsync())
                {
                    var employee = await _dbContext.Employees.FirstOrDefaultAsync(i => i.Id == model.Id);

                    if (employee != null)
                    {
                        employee.FirstName = model.FirstName;
                        employee.LastName = model.LastName;
                        employee.Gender = model.Gender;
                        employee.DateHired = model.DateHired;
                      
                        await _dbContext.SaveChangesAsync();

                       

                        var result = new ResultModel
                        {
                            IsSuccessful = true,
                            Data = employee,
                            Message = "Employee successfully updated!"
                        };

                        tranScope.Commit();

                        return result;
                    }
                    else
                    {
                        return new ResultModel
                        {
                            IsSuccessful = false,
                            Message = "Employee doesn't exist!"
                        };
                    }
                }
            }
        }

        public async Task<ResultModel> GetAll()
        {
            using (_dbContext)
            {
                var employees = await _dbContext.Employees.ToListAsync();

                return new ResultModel
                {
                    IsSuccessful = true,
                    Data = employees
                };
            }
        }

        public async Task<ResultModel> GetById(int EmployeeId)
        {
            using (_dbContext)
            {
                var employee = await _dbContext.Employees.FirstOrDefaultAsync(i => i.Id == EmployeeId);

                if (employee != null)
                {
                    return new ResultModel
                    {
                        IsSuccessful = true,
                        Data = employee
                    };
                } else
                {
                    return new ResultModel
                    {
                        IsSuccessful = false,
                        Message = "Employee doesn't exist!"
                    };
                }
            }
        }
    }
}
