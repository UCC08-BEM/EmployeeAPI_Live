using EmployeeAPI_Live.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


        // Öncelikle manuel bir şekilde bir liste yapısı oluşrup CRUD işlemlerini bunun üzerinde gerçekleştirelim.

        private static List<Employee> employees = new List<Employee>
        {
                new Employee { Id = 1,FName="Ümit",LName="Karaçivi",City="İstanbul"},
                new Employee { Id = 2,FName="Nurgül",LName="Karaçivi",City="Bursa"},
                new Employee { Id = 3,FName="Doğa Bengi",LName="Karaçivi",City="İstanbul"}
        };

        // HTTP RequestTypes - Response Codes
        // CRUD - R
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            return Ok(employees); // BadRequest, NotFound - API nin geri dönüş durumları
        }

        // CRUD - R ById
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeById(int id)
        {
            var employee = employees.Find(e => e.Id == id); // Id ye göre getirilen data

            if (employee == null)
                return BadRequest("Çalışan bulunamadı");

            return Ok(employee); // BadRequest, NotFound - API nin geri dönüş durumları
        }

        // CRUD -C
        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
            employees.Add(employee);

            return Ok(employees); // BadRequest, NotFound - API nin geri dönüş durumları
        }

        // CRUD - U 
        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee data)
        {
            var employee = employees.Find(e => e.Id == data.Id); // Id ye göre getirilen data

            if (employee == null)
                return BadRequest("Çalışan bulunamadı");

            employee.FName = data.FName;
            employee.LName = data.LName;
            employee.City = data.City;

            return Ok(employees); // BadRequest, NotFound - API nin geri dönüş durumları
        }

        // CRUD - D
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var employee = employees.Find(e => e.Id == id); // Id ye göre getirilen data

            if (employee == null)
                return BadRequest("Çalışan bulunamadı");

            employees.Remove(employee);

            return Ok(employees); // BadRequest, NotFound - API nin geri dönüş durumları
        }

    }
}
