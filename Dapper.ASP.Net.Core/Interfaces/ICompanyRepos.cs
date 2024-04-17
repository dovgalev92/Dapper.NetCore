using Dapper.ASP.Net.Core.Models;
using Dapper.ASP.Net.Core.Models.DTO;

namespace Dapper.ASP.Net.Core.Interfaces
{
    public interface ICompanyRepos
    {
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> CreateCompany(CreateCompany create);
        Task<Company> GetCompanyId(int id);
        Task DeleteCompany(int id);
    }
}
