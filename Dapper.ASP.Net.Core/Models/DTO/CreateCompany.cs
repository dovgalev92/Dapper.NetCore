using Microsoft.Identity.Client;

namespace Dapper.ASP.Net.Core.Models.DTO
{
    public class CreateCompany
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
