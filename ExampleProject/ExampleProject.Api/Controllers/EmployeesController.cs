using AutoMapper;
using ExampleProject.Core.Resources;
using ExampleProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper, ILogger<EmployeesController> logger)
        {
            _mapper = mapper;
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResource>> GetById(int id)
        {
            var Employee = await _employeeService.GetEmployeeById(id);
            return Ok(_mapper.Map<EmployeeResource>(Employee));
        }
    }
}
