using EmployeeService.Dats;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Timesheets.Models;
using Timesheets.Models.Options;
using Timesheets.Models.Request;
using Timesheets.Services;

namespace Timesheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentRepository _departmentRepository; 
        private readonly IOptions<LoggerOptions> _loggerOptions;

        public DepartmentController(ILogger<DepartmentController> logger, IOptions<LoggerOptions> loggerOptions, IDepartmentRepository departmentRepository)
        {
            _logger = logger;
            _departmentRepository = departmentRepository;
            _loggerOptions = loggerOptions;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateDepartmentRequest request)
        {
            _logger.LogInformation("Department add");
            var log = _loggerOptions.Value.Path;

            return Ok(_departmentRepository.Create(new Department
            {

                Id = request.Id,

                Description = request.Description

            }));
        }

        #region pp

        [HttpGet("get/all")]
        public ActionResult<List<DepartmentDto>> GetAllDepartment()
        {
            _logger.LogInformation("Department getall");
            var log = _loggerOptions.Value.Path;

            return Ok(_departmentRepository.GetAll().Select(department => new DepartmentDto
            {
                Id = department.Id,
                Description = department.Description,
            }).ToList());
        }

        [HttpGet("get/{id}")]
        public ActionResult<DepartmentDto> GetByIdDepartment([FromRoute] Guid guid)
        {
            _logger.LogInformation("Department get");
            var log = _loggerOptions.Value.Path;

            var department = _departmentRepository.GetById(guid);

            return Ok(new DepartmentDto
            {
                Id = department.Id,
                Description = department.Description,

            });
        }

        #endregion


    }
}
