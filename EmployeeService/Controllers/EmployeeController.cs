using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeService.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusinessController _employeeBusinessController;
        public EmployeeController(IEmployeeBusinessController employeeBusinessController)
        {
            _employeeBusinessController = employeeBusinessController;

        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees(int skip = 0, int limit = 25)
        {
            var employees = await _employeeBusinessController.GetEmployeesAsync(skip, limit);
            var mappedEmployees = employees.Select(Mapper.Map<EmployeeDto>).ToList();
            return Ok(employees);
        }
    }
}