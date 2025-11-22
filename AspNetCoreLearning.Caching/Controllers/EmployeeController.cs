using AspNetCoreLearning.Caching.Model;
using AspNetCoreLearning.Caching.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AspNetCoreLearning.Caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(ICacheService _cacheService) : ControllerBase
    {
        [HttpGet("GetEmplyees")]
        public IActionResult GetEmplyees()
        {
            List<Employee> employees = new List<Employee>();
            employees = _cacheService.GetCacheData(CacheKeys.Employees);
            if (employees == null)
            {
                var dbEmployees = GetEmployeesDeatilsFromDB();
                _cacheService.SetCacheData(CacheKeys.Employees, dbEmployees);
                employees = dbEmployees;
            }
            return Ok(employees);
        }
        [HttpGet("GetEmployeById")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetEmployeById()
        {
            var dbEmployees = GetEmployeesDeatilsFromDB();
            return Ok(dbEmployees);
        }
        private List<Employee> GetEmployeesDeatilsFromDB()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Alice", LastName = "Johnson", EmailId = "alice.johnson@example.com" },
                new Employee { Id = 2, FirstName = "Bob", LastName = "Smith", EmailId = "bob.smith@example.com" },
                new Employee { Id = 3, FirstName = "Charlie", LastName = "Brown", EmailId = "charlie.brown@example.com" },
                new Employee { Id = 4, FirstName = "Diana", LastName = "Prince", EmailId = "diana.prince@example.com" },
                new Employee { Id = 5, FirstName = "Ethan", LastName = "Hunt", EmailId = "ethan.hunt@example.com" },
                new Employee { Id = 6, FirstName = "Fiona", LastName = "Gallagher", EmailId = "fiona.gallagher@example.com" },
                new Employee { Id = 7, FirstName = "George", LastName = "Miller", EmailId = "george.miller@example.com" },
                new Employee { Id = 8, FirstName = "Hannah", LastName = "Lee", EmailId = "hannah.lee@example.com" },
                new Employee { Id = 9, FirstName = "Ian", LastName = "Wright", EmailId = "ian.wright@example.com" },
                new Employee { Id = 10, FirstName = "Julia", LastName = "Roberts", EmailId = "julia.roberts@example.com" }
            };
            return employees;
        }
    }
}
