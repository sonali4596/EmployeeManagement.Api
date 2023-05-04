using AutoMapper;
using Azure;
using EmployeeManagement.Model;
using EmployeeManagementInterface.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace EmployeeManagementInterface.Pages
{
    public class EditEmployeeDetailBase:ComponentBase
    {
        [Inject]
        public IMasterEmployeeService MasterEmployeeService { get; set; }

        private MasterEmployee Employee { get; set; } = new MasterEmployee();

        public MasterEmployeeEdit EditEmployeeModel { get; set; } = new MasterEmployeeEdit();

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);

            if (employeeId != 0)
            {
                Employee = await MasterEmployeeService.GetEmployeeById(int.Parse(Id));
            }
            else
            {
                Employee = new MasterEmployee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    EmployeePhoto = "photo/women.png"
                };
            }
            Departments = (await DepartmentService.GetDepartments()).ToList();
            Mapper.Map(Employee, EditEmployeeModel);
        }
        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);
            MasterEmployee user = null;
            HttpResponseMessage result = null;

            if (Employee.Id != 0)
            {
                result = await MasterEmployeeService.UpdateInfoEmployee(Employee);
                var responseContent = await result.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<MasterEmployee>(responseContent);
            }
            else
            {
                result = await MasterEmployeeService.CreateEmployee(Employee);
                var responseContent = await result.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<MasterEmployee>(responseContent);
            }
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }

        }
        protected async Task Delete_Click()
        {
            await MasterEmployeeService.DeleteEmployee(Employee.Id);
            NavigationManager.NavigateTo("/");
        }
    }
}
