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
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _crudAppDbContext.Employees.ToListAsync();

            return Ok(employees);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody]Employee employee)
        {
            employee.Id = Guid.NewGuid();

            await _crudAppDbContext.Employees.AddAsync(employee);
            await _crudAppDbContext.SaveChangesAsync();

            return Ok(employee);
        }
    }
}
