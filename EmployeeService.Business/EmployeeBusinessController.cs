using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Business.Dto;
using EmployeeService.Common;

namespace EmployeeService.Business
{
    public class EmployeeBusinessController : IEmployeeBusinessController
    {
        private readonly IAppSettings _appSettings;
        public EmployeeBusinessController(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public Task<List<Employee>> GetEmployeesAsync(int skip = 0, int limit = 25)
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
            
            var employees = new List<Employee>()
            {
                new Employee { EmployeeId = Guid.NewGuid(), FirstName= "Ma", LastName = "T"},
                new Employee { EmployeeId = Guid.NewGuid(), FirstName= "Ab", LastName = "K"},
                new Employee { EmployeeId = Guid.NewGuid(), FirstName= "Ak", LastName = "G"}
            };

            return Task.FromResult<List<Employee>>(employees);
        }
    }
}
