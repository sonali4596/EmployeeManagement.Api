using EmployeeManagement.Model;
using EmployeeManagementInterface.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagementInterface.Pages
{
    public class EmployeeListBase:ComponentBase
    {
        [Inject]
        public IMasterEmployeeService IMasterEmployeeService { get; set; }
        public IEnumerable<MasterEmployee> Employees { get; set; }
        protected  async Task EmployeeDeleted()
        {
            Employees=(await IMasterEmployeeService.GetAllEmployees()).ToList();

        }
        protected override async Task OnInitializedAsync()
        {
            Employees = (await IMasterEmployeeService.GetAllEmployees()).ToList();
        }
    }
}
