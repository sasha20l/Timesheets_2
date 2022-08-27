using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Timesheets.Models.Request;
using Timesheets.Services;

namespace Timesheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        public EmployeeTypeController(IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateEmployeeTypeRequest request)
        {
            return Ok(_employeeTypeRepository.Create(new Models.EmployeeType
            {

                Id = request.Id,

                Description = request.Description

            }));
        }

        [HttpGet("get/all")]
        public IActionResult GetAllEmployeeType()
        {
            return Ok(_employeeTypeRepository.GetAll());
        }

        [HttpGet("get/{id}")]
        public IActionResult GetByIdDepartment([FromRoute] int id)
        {
            return Ok(_employeeTypeRepository.GetById(id));
        }




    }
}
