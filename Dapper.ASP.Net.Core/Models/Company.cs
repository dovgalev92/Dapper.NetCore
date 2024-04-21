﻿using Microsoft.AspNetCore.Mvc.Formatters;

namespace Dapper.ASP.Net.Core.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
