using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository:IMasterEmployeeRepository
    {   private AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext) 
        {
            this._appDbContext = appDbContext;
        }

        public async Task<MasterEmployee> AddEmployee(MasterEmployee employee)
        {
           var result= await _appDbContext.MasterEmployees.AddAsync(employee);
            _appDbContext.SaveChanges();
            return result.Entity;
        }
  
        public async Task<MasterEmployee> DeleteEmployee(int employeeId)
        {
            var result =await _appDbContext.MasterEmployees.FirstOrDefaultAsync(e=>e.Id==employeeId);
            if (result != null)
            {
                _appDbContext.MasterEmployees.Remove(result);
                 await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<IEnumerable<MasterEmployee>> SearchEmployee(string? name,int phone,string?email)
        {
            IQueryable<MasterEmployee> query =_appDbContext.MasterEmployees;
            if ( !string.IsNullOrEmpty(name))
            {
               query=query.Where(e=>e.Name.Contains(name));
            }
            if(phone> 0)
            {query=query.Where(e=>e.Phone==phone);
            }
            if(!string.IsNullOrEmpty(email))
            {
                query=query.Where(e=>e.Email==email);
            }
            return await query.ToListAsync();
        }

        public async Task<MasterEmployee> GetEmployeeById(int employeeId)
        {
            return await _appDbContext.MasterEmployees.FirstOrDefaultAsync(e => e.Id == employeeId);
        }
        public async Task<IEnumerable<MasterEmployee>> GetAllEmployees()
        {
            return await _appDbContext.MasterEmployees.ToListAsync();
        }

        public async Task<MasterEmployee> UpdateEmployee(MasterEmployee employee)
        {
            var result =await _appDbContext.MasterEmployees.FirstOrDefaultAsync(e=>e.Id == employee.Id);
            if(result != null)
            {
                result.Name = employee.Name;
                result.Email = employee.Email;
                result.Phone = employee.Phone;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.JoiningDate = employee.JoiningDate;
                result.EmploymentExpiryDate = employee.EmploymentExpiryDate;
                result.EmployeePhoto = employee.EmployeePhoto;
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }



    }
}
