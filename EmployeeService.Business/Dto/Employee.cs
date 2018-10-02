using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeService.Business.Dto
{
    public class Employee
    {
        [JsonProperty("id")]
        public string EmployeeId { get; set; }
        [JsonProperty("employee_name")]
        public string Name { get; set; }

        [JsonProperty("employee_salary")]
        public double Salary { get; set; }

        [JsonProperty("employee_age")]
        public int Age { get; set; }
        [JsonProperty("profile_image")]
        public string ImageUrl { get; set; }
    }
}
