using Dapper.ASP.Net.Core.Interfaces;
using Dapper.ASP.Net.Core.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.ASP.Net.Core.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepos _companyRepos;
        public CompanyController(ICompanyRepos companyRepos)
        {
            _companyRepos = companyRepos;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompany create)
        {
            if (create == null)
            {
                throw new ArgumentNullException(nameof(create));
            }
            var newCompany = await _companyRepos.CreateCompany(create);
            return CreatedAtRoute(nameof(GetCompanyId), new { id = newCompany.Id }, newCompany);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCompanyes()
        {
            var comapany = await _companyRepos.GetCompanies();
            return Ok(comapany);
        }
        [HttpGet("{id}", Name = "GetCompanyId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCompanyId(int id)
        {
            var companyId = await _companyRepos.GetCompanyId(id);
            if (companyId == null)
                return NotFound();
            return Ok(companyId);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companyRepos.DeleteCompany(id);
            return NoContent();
        }
    }
}
