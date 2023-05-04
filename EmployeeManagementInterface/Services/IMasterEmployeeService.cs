using EmployeeManagement.Model;

namespace EmployeeManagementInterface.Services
{
    public interface IMasterEmployeeService
    {
        Task<IEnumerable<MasterEmployee>> GetAllEmployees();
        Task<MasterEmployee> GetEmployeeById(int id);
        Task<HttpResponseMessage> UpdateInfoEmployee(MasterEmployee employee);
        Task<HttpResponseMessage> CreateEmployee(MasterEmployee newEmployee);
        Task DeleteEmployee(int id);
    }
}
