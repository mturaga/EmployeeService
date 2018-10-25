using EmployeeService.Business.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Business.Application.Employees.Queries
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<Employee>>
    {
        private readonly IEmployeeBusinessController _businessController;

        public GetEmployeeQueryHandler(IEmployeeBusinessController employeeBusinessController)
        {
            _businessController = employeeBusinessController;
        }
        public async Task<List<Employee>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _businessController.GetEmployeesAsync();            
            
        }
    }
}
