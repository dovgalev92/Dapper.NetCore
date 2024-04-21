using Dapper.ASP.Net.Core.Context;
using Dapper.ASP.Net.Core.Interfaces;
using Dapper.ASP.Net.Core.Models;
using Dapper.ASP.Net.Core.Models.DTO;
using System.Data;

namespace Dapper.ASP.Net.Core.ImplementationRepos
{
    public class EmplementationCompany : ICompanyRepos
    {
        private readonly DapperContext _context;
        public EmplementationCompany(DapperContext context)
        {
            _context = context;
        }
        public async Task<Company>CreateCompany(CreateCompany create)
        {
            var query = "INSERT INTO Companies(Name, Country) VALUES (@Name, @Country)" +
                "SELECT CAST (SCOPE_IDENTITY() as int)";

            var parametr = new DynamicParameters();
            parametr.Add("Name", create.Name, DbType.String);
            parametr.Add("Country", create.Country, DbType.String);

            using (var connection = _context.ConnectionDataBase())
            {
                var id = await connection.QuerySingleAsync<int>(query, parametr);
                var createCompany = new Company
                {
                    Id = id,
                    Name = create.Name,
                    Country = create.Country
                };
                return createCompany;
            }
        }
        public async Task DeleteCompany(int id)
        {
            var query = "DELETE FROM Companies Where id = @id";
            using (var connection = _context.ConnectionDataBase())
            {
                await connection.ExecuteAsync(query, new { id});
            }
        }
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = "SELECT * FROM Companies c JOIN Employees e ON c.Id = e.CompanyId";
            using (var connection = _context.ConnectionDataBase())
            {
                var dict = new Dictionary<int, Company>();
                var companies = await connection.QueryAsync<Company, Employee, Company>(
                    query, (company, employee) =>
                    {
                        if (!dict.TryGetValue(company.Id, out var currentCompany))
                        {
                            currentCompany = company;
                            dict.Add(company.Id, currentCompany);
                        }
                        currentCompany.Employees.Add(employee);
                        return currentCompany;
                    });
                return companies.Distinct().ToList();
            }
        }
        public async Task<Company> GetCompanyId(int id)
        {
            var query = "SELECT * FROM Companies WHERE Id = @id " +
                  " SELECT * FROM Employees WHERE CompanyId = @id";

            using ( var connection = _context.ConnectionDataBase())
            using (var multi = await connection.QueryMultipleAsync(query, new {id}))
            {
                var companies = await multi.ReadSingleOrDefaultAsync<Company>();
                if (companies != null)
                companies.Employees = (await multi.ReadAsync<Employee>()).ToList();
                return companies;
            }
        }
    }
}
