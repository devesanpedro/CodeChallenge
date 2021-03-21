using CodeChallenge.Service.Models;
using CodeChallenge.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Web.Pages
{
    public class UpdateEmployeeDialogBase : ComponentBase
    {
        [Inject]
        NavigationManager navigationManager { get; set; }

        public string ModalDisplay = "none;";

        public string ModalClass = "";

        public bool ShowBackdrop = false;

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public EmployeeModel model = new EmployeeModel();

        public EditContext editContext;

        public async void OpenDialog(int EmployeeId)
        {
            await GetEmployeeById(EmployeeId);
            ModalDisplay = "block;";
            ModalClass = "Show";
            ShowBackdrop = true;
            StateHasChanged();
        }

        public void CloseDialog()
        {
            ModalDisplay = "none";
            ModalClass = "";
            ShowBackdrop = false;
            StateHasChanged();
        }

        public async Task GetEmployeeById(int EmployeeId)
        {
            var result = await EmployeeService.GetById(EmployeeId);

            if (result.IsSuccessful)
            {
                var employee = JsonConvert.DeserializeObject<EmployeeModel>(JsonConvert.SerializeObject(result.Data));
                    
                model = employee;
            }
        }

        public async Task Submit()
        {
            var result = await EmployeeService.Edit(model);

            if (result.IsSuccessful)
            {
                navigationManager.NavigateTo("/", true);
                this.CloseDialog();
            }
          
        }
    }
}
