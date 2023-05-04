using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public class MasterEmployeeEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public int Phone { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime EmploymentExpiryDate { get; set; }
        public string EmployeePhoto { get; set; }
        public int DepartmentId { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
    }
}
