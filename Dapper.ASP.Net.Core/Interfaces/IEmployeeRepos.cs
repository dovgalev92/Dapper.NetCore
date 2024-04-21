using Dapper.ASP.Net.Core.Models;
using Dapper.ASP.Net.Core.Models.DTO;

namespace Dapper.ASP.Net.Core.Interfaces
{
    public interface IEmployeeRepos
    {
        Task<Employee>CreateEmployee(CreateEmployee employee);
    }
}
