using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeService.Business.Application.Employees.Queries
{
    public class GetEmployeeQuery : IRequest<List<Dto.Employee>>
    {
        public int PageSize { get; set; } 
        public int Limit  { get; set; }
    }
}
