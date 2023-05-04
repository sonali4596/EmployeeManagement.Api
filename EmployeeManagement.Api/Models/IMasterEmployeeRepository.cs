using EmployeeManagement.Model;

namespace EmployeeManagement.Api.Models
{
    public interface IMasterEmployeeRepository
    {
        Task<IEnumerable<MasterEmployee>> GetAllEmployees();
        Task<MasterEmployee> GetEmployeeById(int id);
        Task<MasterEmployee> AddEmployee(MasterEmployee masterEmployee);
        Task<MasterEmployee> UpdateEmployee(MasterEmployee masterEmployee);
        Task<MasterEmployee> DeleteEmployee(int id);
        Task<IEnumerable<MasterEmployee>> SearchEmployee(string? name, int phone, string? email);
    }
}
