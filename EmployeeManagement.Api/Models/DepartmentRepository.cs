using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;
        public DepartmentRepository(AppDbContext appDbContext) 
        {
            this._appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Department>> GetDepartments()
        {
             return await _appDbContext.Departments.ToListAsync();
        }
        public async Task<Department> GetDepartment(int id)
        {
            return await _appDbContext.Departments.FirstOrDefaultAsync(d => d.Id == id);
        }

    }
}
