using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeAPI_Live.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();

            string apiUrl = "https://localhost:7049/api/EmployeeEF";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.GetAsync(apiUrl + "/GetEmployees").Result;

            if (response.IsSuccessStatusCode)
            {
                employees = JsonConvert.DeserializeObject<List<Employee>>(response.Content.ReadAsStringAsync().Result);
            }


            return View(employees);
        }

        //[HttpPost]
        //public IActionResult Index(int id)
        //{
        //    List<Employee> employees = new List<Employee>();

        //    string apiUrl = "https://localhost:7049/api/EmployeeEF";

        //    HttpClient client = new HttpClient();

        //    HttpResponseMessage response = client.GetAsync(apiUrl + "/GetEmployeeById/" + id.ToString()).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        employees = JsonConvert.DeserializeObject<List<Employee>>(response.Content.ReadAsStringAsync().Result);
        //    }


        //    return View(employees);
        //}
    }
}
