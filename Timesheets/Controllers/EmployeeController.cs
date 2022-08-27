using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Timesheets.Models.Request;
using Timesheets.Services;

namespace Timesheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateEmployeeRequest request)
        {
            return Ok(_employeeRepository.Create(new Models.Employee
            {
                DepartmentId = request.DepartmentId,
                EmployeeTypeId = request.EmployeeTypeId,
                FirstName = request.FirstName,
                Patronymic = request.Patronymic,
                Salary = request.Salary,
                Surname = request.Surname

            }));
        }

        [HttpGet("get/all")]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeRepository.GetAll());
        }

        [HttpGet("get/{id}")]
        public IActionResult GetByIdEmployees([FromRoute] int id)
        {
            return Ok(_employeeRepository.GetById(id));
        }
    }
}
