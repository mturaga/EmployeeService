using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeService.Business;
using EmployeeService.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;

namespace EmployeeService.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusinessController _employeeBusinessController;
        private readonly IAppSettings _appSettings;

        public EmployeeController(IEmployeeBusinessController employeeBusinessController, IOptions<AppSettings> appSettingOptions, ILogger<EmployeeBusinessController> logger)
        {
            _appSettings = appSettingOptions.Value;
            _employeeBusinessController = employeeBusinessController;

        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees(int skip = 0, int limit = 25)
        {
            Log.Information("GetEmployee --> Start");
            var employees = await _employeeBusinessController.GetEmployeesAsync(skip, limit);
            var mappedEmployees = employees.Select(Mapper.Map<EmployeeDto>).ToList();
            Log.Information("GetEmployee --> Done");
            return Ok(employees);
           
        }
    }
}