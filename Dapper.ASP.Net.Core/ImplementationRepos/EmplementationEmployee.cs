using Dapper.ASP.Net.Core.Context;
using Dapper.ASP.Net.Core.Interfaces;
using Dapper.ASP.Net.Core.Models;
using Dapper.ASP.Net.Core.Models.DTO;
using System.Data;

namespace Dapper.ASP.Net.Core.ImplementationRepos
{
    public class EmplementationEmployee : IEmployeeRepos
    {
        private readonly DapperContext _context;
        public EmplementationEmployee(DapperContext context)
        {
            _context = context;
        }
        public async Task<Employee>CreateEmployee(CreateEmployee employee)
        {
            var query = "INSERT INTO Employees(Name, CompanyId) VALUES (@Name, @CompanyId)" +
                "SELECT CAST (SCOPE_IDENTITY() as int)";

            var parametrs = new DynamicParameters();
            parametrs.Add("Name", employee.Name, DbType.String);
            parametrs.Add("CompanyId",employee.CompanyId, DbType.Int32);

            using (var connect = _context.ConnectionDataBase())
            {
                var idEmpl = await connect.QuerySingleAsync<int>(query, parametrs);
                var createEmp = new Employee
                {
                    Id = idEmpl,
                    Name = employee.Name,
                    CompanyId = employee.CompanyId,
                };
                return createEmp;
            }
        }
    }
}
