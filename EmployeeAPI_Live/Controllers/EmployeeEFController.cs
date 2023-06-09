using EmployeeAPI_Live.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI_Live.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeEFController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeEFController(AppDbContext context)
        {
            _context = context;
        }



        // HTTP RequestTypes - Response Codes
        // CRUD - Read
        [HttpGet]
        [Route("GetEmployees")]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(await _context.Employees.ToListAsync()); // BadRequest, NotFound - API nin geri dönüş durumları
        }

        // CRUD - Read ById
        [HttpGet("{id}")]
        [Route("GetEmployeeById")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id); // Id ye göre getirilen data

            if (employee == null)
                return BadRequest("Çalışan bulunamadı");

            return Ok(employee); // BadRequest, NotFound - API nin geri dönüş durumları
        }

        // CRUD -C
        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync()); // BadRequest, NotFound - API nin geri dönüş durumları
        }

        // CRUD - U 
        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee data)
        {
            var employee = await _context.Employees.FindAsync(data.Id); // Id ye göre getirilen data

            if (employee == null)
                return BadRequest("Çalışan bulunamadı");

            employee.FName = data.FName;
            employee.LName = data.LName;
            employee.City = data.City;

            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync()); // BadRequest, NotFound - API nin geri dönüş durumları
        }

        // CRUD - D
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id); // Id ye göre getirilen data

            if (employee == null)
                return BadRequest("Çalışan bulunamadı");

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync()); // BadRequest, NotFound - API nin geri dönüş durumları
        }

    }
}
