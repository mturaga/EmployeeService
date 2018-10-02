using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Business.Clients;
using EmployeeService.Business.Dto;
using EmployeeService.Common;
using Newtonsoft.Json;
using Serilog;

namespace EmployeeService.Business
{
    public class EmployeeBusinessController : IEmployeeBusinessController
    {
        private readonly IAppSettings _appSettings;
        private readonly IEmployeeClient _employeeClient;
        public EmployeeBusinessController( IEmployeeClient employeeClient,IAppSettings appSettings)
        {
            _appSettings = appSettings;
            _employeeClient = employeeClient;
        }

        public async Task<List<Employee>> GetEmployeesAsync(int skip = 0, int limit = 25)
        {
            var normalizedLimit = 0;
            if(limit <= 0)
            {
                normalizedLimit = _appSettings.DefaultPageSize;
            }
            else
            {
                normalizedLimit = limit;
            }
            Log.Information("Business ==> GetEmployeeAsync");

            return await _employeeClient.GetEmployees();
        }
    }
}
