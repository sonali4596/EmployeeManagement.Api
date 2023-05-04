using EmployeeManagement.Model;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace EmployeeManagementInterface.Services
{
    public class EmployeeService:IMasterEmployeeService
    {private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;   
        }
        public async Task<IEnumerable<MasterEmployee>> GetAllEmployees()
        {
            return await _httpClient.GetFromJsonAsync<MasterEmployee[]>("api/MasterEmployee");
        }
        public async Task<MasterEmployee> GetEmployeeById(int id)
        {
            return await _httpClient.GetFromJsonAsync<MasterEmployee>($"api/MasterEmployee/{id}");
        }
        public async Task<HttpResponseMessage> UpdateInfoEmployee(MasterEmployee employee)
        {
            var response= await _httpClient.PutAsJsonAsync<MasterEmployee>($"api/MasterEmployee/{employee.Id}", employee);
            return response;
        }
        public async Task<HttpResponseMessage> CreateEmployee(MasterEmployee newEmployee)
        {
            return await _httpClient.PostAsJsonAsync<MasterEmployee>("api/MasterEmployee/", newEmployee);
        }
        public async Task DeleteEmployee(int id)
        {
            await _httpClient.DeleteAsync($"api/MasterEmployee/{id}");
        }
    }
}
