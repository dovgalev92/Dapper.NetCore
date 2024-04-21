using Dapper.ASP.Net.Core.Interfaces;
using Dapper.ASP.Net.Core.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.ASP.Net.Core.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepos _repos;
        public EmployeeController(IEmployeeRepos repos)
        {
            _repos = repos;
        }
        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateEmployee(int id, [FromBody] CreateEmployee employee)
        {
            employee.CompanyId = id;
            var createEmpl = await _repos.CreateEmployee(employee);
            return Ok(createEmpl);
        }
    }
}
