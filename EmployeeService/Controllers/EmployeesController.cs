using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeService.Business;
using EmployeeService.Business.Dto;
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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeBusinessController _employeeBusinessController;
        private readonly IAppSettings _appSettings;
        private readonly IMapper _mapper;
        

        public EmployeesController(IEmployeeBusinessController employeeBusinessController, IOptions<AppSettings> appSettingOptions, ILogger<EmployeeBusinessController> logger, IMapper mapper)
        {
            _appSettings = appSettingOptions.Value;
            _employeeBusinessController = employeeBusinessController;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees(int skip = 0, int limit = 25)
        {
            var employees = new List<Employee>(); ;
            try
            {
                Log.Information("GetEmployee --> Start");
                employees = await _employeeBusinessController.GetEmployeesAsync(skip, limit);
                var mappedEmployees = employees.Select(_mapper.Map<EmployeeDto>).ToList();
                Log.Information("GetEmployee --> Done");
               
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);
            }
            return Ok(employees);

        }
    }
}