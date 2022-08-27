using EmployeeService.Dats;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Timesheets.Models.Options;
using Timesheets.Models;
using Timesheets.Models.Request;
using Timesheets.Services;

namespace Timesheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOptions<LoggerOptions> _loggerOptions;

        public EmployeeController(ILogger<EmployeeController> logger, IOptions<LoggerOptions> loggerOptions, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _loggerOptions = loggerOptions;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateEmployeeRequest request)
        {
            _logger.LogInformation("Employee add");
            var log = _loggerOptions.Value.Path;

            return Ok(_employeeRepository.Create(new Employee
            {

                Id = request.Id,
                DepartmentId = request.DepartmentId,
                EmployeeTypeId = request.EmployeeTypeId,
                FirstName = request.FirstName,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                Salary = request.Salary

            }));
        }

        [HttpGet("get/all")]
        public ActionResult<List<EmployeeDto>> GetAllEmployee()
        {
            _logger.LogInformation("Employee getall");
            var log = _loggerOptions.Value.Path;

            return Ok(_employeeRepository.GetAll().Select(employee => new EmployeeDto
            {
                Id = employee.Id,
                DepartmentId = employee.DepartmentId,
                EmployeeTypeId = employee.EmployeeTypeId,
                FirstName = employee.FirstName,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Salary = employee.Salary

            }).ToList());
        }

        [HttpGet("get/{id}")]
        public ActionResult<EmployeeDto> GetByIdEmployee([FromRoute] int id)
        {
            _logger.LogInformation("Employee get");
            var log = _loggerOptions.Value.Path;

            var employee = _employeeRepository.GetById(id);

            return Ok(new EmployeeDto
            {
                Id = employee.Id,
                DepartmentId = employee.DepartmentId,
                EmployeeTypeId = employee.EmployeeTypeId,
                FirstName = employee.FirstName,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Salary = employee.Salary

            });
        }
    }
}
