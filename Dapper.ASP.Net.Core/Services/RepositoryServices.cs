using Dapper.ASP.Net.Core.ImplementationRepos;
using Dapper.ASP.Net.Core.Interfaces;

namespace Dapper.ASP.Net.Core.Services
{
    public static class RepositoryServices
    {
        public static IServiceCollection AddServicesRepo(this IServiceCollection services)
        {
            services.AddScoped<ICompanyRepos, EmplementationCompany>();
            services.AddScoped<IEmployeeRepos, EmplementationEmployee>();
            return services;
        }
    }
}
