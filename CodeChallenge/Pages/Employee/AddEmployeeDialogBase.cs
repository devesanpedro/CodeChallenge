using CodeChallenge.Service.Models;
using CodeChallenge.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Web.Pages
{
    public class AddEmployeeDialogBase : ComponentBase
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

        public void OpenDialog()
        {
            ModalDisplay = "block;";
            ModalClass = "Show";
            ShowBackdrop = true;
            StateHasChanged();
        }

        public void CloseDialog()
        {
            model = new EmployeeModel();
            ModalDisplay = "none";
            ModalClass = "";
            ShowBackdrop = false;
            StateHasChanged();
        }

        public async Task Submit()
        {
            var result = await EmployeeService.Add(model);

            if (result.IsSuccessful)
            {
                navigationManager.NavigateTo("/", true);
                this.CloseDialog();
            }
           
        }

        protected override void OnInitialized()
        {
            editContext = new EditContext(model);
        }
    }
}
