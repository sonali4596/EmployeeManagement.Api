using EmployeeManagement.Api.Models;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterEmployeeController : ControllerBase
    {
        private readonly IMasterEmployeeRepository _masterEmployeeRepository;
        public MasterEmployeeController(IMasterEmployeeRepository masterEmployeeRepository)
        {
            _masterEmployeeRepository = masterEmployeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await _masterEmployeeRepository.GetAllEmployees());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MasterEmployee>> GetEmployeeById(int id)
        {
            try
            {
                var result = await _masterEmployeeRepository.GetEmployeeById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<MasterEmployee>> AddEmployee(MasterEmployee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                var addedEmployee = await _masterEmployeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = addedEmployee.Id }, addedEmployee);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateEmployee( int id,[FromBody]  MasterEmployee employee)
        {
            try
            {
                
                var employeeForUpdate = await _masterEmployeeRepository.GetEmployeeById(employee.Id);
                if (employeeForUpdate == null)
                {
                    return NotFound($"Employee With id ={employee.Id} is not Found");
                }
                 await _masterEmployeeRepository.UpdateEmployee(employee);
                return Ok(employeeForUpdate);
                
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MasterEmployee>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await _masterEmployeeRepository.GetEmployeeById(id);
                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with id={id} Not Found");
                }
                return await _masterEmployeeRepository.DeleteEmployee(id);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{Search}")]
        public async Task<ActionResult<IEnumerable<MasterEmployee>>> Search(string? name, int phone, string? email)
        {
            try
            {
                var result=await _masterEmployeeRepository.SearchEmployee(name, phone, email);
                if(result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch(Exception ex) { return StatusCode(500, ex.Message); }
        }

    }
}
