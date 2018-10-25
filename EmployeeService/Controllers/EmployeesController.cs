using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeService.Business;
using EmployeeService.Business.Dto;
using EmployeeService.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;

namespace EmployeeService.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IMediator _mediator;
        public EmployeesController(ILogger<EmployeeBusinessController> logger, IMediator mediator) 
        {
            _mediator = mediator; 
        }  

        [HttpGet]
        public async Task<ActionResult> GetEmployees(int skip = 0, int limit = 25)
        {
            var response = new ServiceResponse<List<Employee>>();
            
            try
            {
                var employees = await _mediator.Send(new Business.Application.Employees.Queries.GetEmployeeQuery { PageSize = limit, Limit = skip });
                response.Data = employees;
               
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);
            }
            return Ok(response);

        }
    }
}