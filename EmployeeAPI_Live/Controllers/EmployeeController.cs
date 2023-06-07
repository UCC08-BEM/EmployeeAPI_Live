using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI_Live.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // Öncelikle manuel bir şekilde bir liste yapısı oluşrup CRUD işlemlerini bunun üzerinde gerçekleştirelim.

        private static List<Employee> employees = new List<Employee>
        {
                new Employee { Id = 1,FName="Ümit",LName="Karaçivi",City="İstanbul"},
                new Employee { Id = 2,FName="Nurgül",LName="Karaçivi",City="Bursa"},
                new Employee { Id = 3,FName="Doğa Bengi",LName="Karaçivi",City="İstanbul"}
        };
    }
}
