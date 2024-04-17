using Dapper.ASP.Net.Core.Context;

namespace Dapper.ASP.Net.Core.Services
{
    public static class ConfigureService
    {
        public  static IServiceCollection AddConfigureDapper(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            return services;
        }
    }
}
