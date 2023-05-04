using EmployeeManagement.Model;
using EmployeeManagementInterface.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagementInterface.Pages
{
    public class EmployeeDetailBase:ComponentBase
    {
        //[Parameter]
        //public MasterEmployee Employee { get; set; }
        public MasterEmployee Employee { get; set; } = new MasterEmployee();

        [Inject]
        public IMasterEmployeeService MasterEmployeeService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }
        


        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await MasterEmployeeService.GetEmployeeById(int.Parse(Id));

        }
        protected async Task Delete_Click()
        {
            await MasterEmployeeService.DeleteEmployee(Employee.Id);
            await OnEmployeeDeleted.InvokeAsync(Employee.Id);
            
        }
    }
}
