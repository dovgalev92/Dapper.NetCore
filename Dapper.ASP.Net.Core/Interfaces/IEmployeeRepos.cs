using Dapper.ASP.Net.Core.Models;

namespace Dapper.ASP.Net.Core.Interfaces
{
    public interface IEmployeeRepos
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task CreateEmployee(int id, Employee employee);
        Task<Employee> GetEmployeeId(int id);
        Task DeleteEmployee(int id);
    }
}
