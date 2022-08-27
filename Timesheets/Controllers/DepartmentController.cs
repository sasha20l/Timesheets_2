using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;
using Timesheets.Models.Options;
using Timesheets.Models.Request;
using Timesheets.Services;

namespace Timesheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository; 
        //private readonly IOptions _loggerOptions;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            //_loggerOptions = loggerOptions;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateDepartmentRequest request)
        {
            return Ok(_departmentRepository.Create(new Models.Department
            {

                Id = request.Id,

                Description = request.Description

            }));
        }

        #region pp

        [HttpGet("get/all")]
        public IActionResult GetAllDepartment()
        {
            return Ok(_departmentRepository.GetAll());
        }

        [HttpGet("get/{id}")]
        public IActionResult GetByIdDepartment([FromRoute] Guid guid)
        {
            //var log = _loggerOptions.Value.Path;
            return Ok(_departmentRepository.GetById(guid));
        }

        #endregion


    }
}
