using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Business.Dto;
using EmployeeService.Common;
using Newtonsoft.Json;

namespace EmployeeService.Business.Clients
{
    public class EmployeeClient : IEmployeeClient
    {
        private readonly HttpClient _httpClient;
        private readonly IAppSettings _appSettings;
        public EmployeeClient(HttpClient httpClient, IAppSettings appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            var employeeResult = await _httpClient.GetStringAsync("employees");
            var employees = JsonConvert.DeserializeObject<List<Employee>>(employeeResult);
            return employees;
        }
    }
}
