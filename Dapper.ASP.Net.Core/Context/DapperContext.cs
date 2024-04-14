using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper.ASP.Net.Core.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _conection;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _conection = _configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection ConnectionDataBase() => new SqlConnection(_conection);
    }
}
