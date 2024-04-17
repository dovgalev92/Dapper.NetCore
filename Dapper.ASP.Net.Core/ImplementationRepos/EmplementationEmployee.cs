using Dapper.ASP.Net.Core.Interfaces;
using Dapper.ASP.Net.Core.Models;

namespace Dapper.ASP.Net.Core.ImplementationRepos
{
    public class EmplementationEmployee : IEmployeeRepos
    {
        public Task CreateEmployee(int id, Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
