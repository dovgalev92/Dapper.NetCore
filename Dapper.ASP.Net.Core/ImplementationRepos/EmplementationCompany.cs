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

        public Task DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = "SELECT * FROM Companies";
            using (var connection = _context.ConnectionDataBase())
            {
                var companyes = await connection.QueryAsync<Company>(query);   
                return companyes.ToList();
            }
        }

        public async Task<Company> GetCompanyId(int id)
        {
            var query = "SELECT * FROM Companies WHERE Id = @id";

            using (var connection = _context.ConnectionDataBase())
            {
                var getId = await connection.QuerySingleOrDefaultAsync<Company>(query, new { id });
                return getId;
            }
        }
    }
}
