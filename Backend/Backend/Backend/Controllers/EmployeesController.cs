using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly CrudAppDbContext _crudAppDbContext;
        public EmployeesController(CrudAppDbContext crudAppDbContext)
        {
            _crudAppDbContext = crudAppDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees([FromQuery] int page, [FromQuery] int pageSize)
        {
            var totalCount = await _crudAppDbContext.Employees.CountAsync();
            var employees = await _crudAppDbContext.Employees.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return Ok(new
            {
                StatusCode = 200,
                Data = employees,
                TotalCount = totalCount
            });
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody]Employee employee)
        {
            employee.Id = Guid.NewGuid();

            await _crudAppDbContext.Employees.AddAsync(employee);
            await _crudAppDbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmplyee([FromRoute] Guid id)
        {
            var employee = await _crudAppDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if(employee == null)
            {
                return NotFound();
            }

            //else found

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id ,Employee req)
        {
            var employee = await _crudAppDbContext.Employees.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            employee.Name = req.Name;
            employee.Email = req.Email;
            employee.Phone = req.Phone;
            employee.Salary = req.Salary;
            employee.Department = req.Department;

            await _crudAppDbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _crudAppDbContext.Employees.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            _crudAppDbContext.Employees.Remove(employee);

            await _crudAppDbContext.SaveChangesAsync();

            return Ok(employee);
        }
    }
}