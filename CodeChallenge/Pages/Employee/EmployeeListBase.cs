
using CodeChallenge.Service.Models;
using CodeChallenge.Web.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Web.Pages.Employee;

namespace CodeChallenge.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<EmployeeModel> Employees { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public AddEmployeeDialogBase AddEmployeeDialog { get; set; }
        public UpdateEmployeeDialogBase UpdateEmployeeDialog { get; set; }
        public DeleteEmployeeDialogBase DeleteEmployeeDialog { get; set; }

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
