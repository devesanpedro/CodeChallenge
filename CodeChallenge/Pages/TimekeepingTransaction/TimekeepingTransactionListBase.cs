using CodeChallenge.Service.Models;
using CodeChallenge.Web.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Web.Pages.TimekeepingTransaction
{
    public class TimekeepingTransactionListBase : ComponentBase
    {
        public IEnumerable<TimekeepingTransactionModel> TkTransactions { get; set; }
        public IEnumerable<EmployeeModel> Employees { get; set; }

        public string SelectedEmployeeId { get; set; } = "";

        [Inject]
        public ITimekeepingTransactionService TimekeepingTransactionService { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public void OnValueChanged(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                SelectedEmployeeId = value;

                this.GetTransactionByEmployeeId(int.Parse(value));
            }
        }

        public async void TimeIn()
        {
            if (!string.IsNullOrEmpty(SelectedEmployeeId))
            {
                var tkTransactionModel = new TimekeepingTransactionModel()
                {
                    EmployeeId = int.Parse(SelectedEmployeeId),
                    TransactionDateTime = DateTime.Now,
                    TransactionTypeId = 1 //Time In
                };

                var result = await TimekeepingTransactionService.Add(tkTransactionModel);

                this.GetTransactionByEmployeeId(int.Parse(SelectedEmployeeId));

            }
        }

        public async void TimeOut()
        {
            if (!string.IsNullOrEmpty(SelectedEmployeeId))
            {
                var tkTransactionModel = new TimekeepingTransactionModel()
                {
                    EmployeeId = int.Parse(SelectedEmployeeId),
                    TransactionDateTime = DateTime.Now,
                    TransactionTypeId = 2 //Time Out
                };

                var result = await TimekeepingTransactionService.Add(tkTransactionModel);

                this.GetTransactionByEmployeeId(int.Parse(SelectedEmployeeId));

            }
        }

        public async void GetTransactionByEmployeeId(int EmployeeId)
        {
            var result = await TimekeepingTransactionService.GetAllByEmployeeId(EmployeeId);

            if (result.IsSuccessful)
            {
                var transactions = JsonConvert.DeserializeObject<IEnumerable<TimekeepingTransactionModel>>(JsonConvert.SerializeObject(result.Data));
                TkTransactions = transactions;
            }
        }

        protected async override Task OnInitializedAsync()
        {
            var result = await EmployeeService.GetAll();

            if (result.IsSuccessful)
            {
                var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(JsonConvert.SerializeObject(result.Data));
                Employees = employees;
            }
        }

    }
}
