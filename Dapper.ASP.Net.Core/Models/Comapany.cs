namespace Dapper.ASP.Net.Core.Models
{
    public class Comapany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
