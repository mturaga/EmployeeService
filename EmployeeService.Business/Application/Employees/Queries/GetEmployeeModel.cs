using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeService.Business.Application.Employees.Queries
{
    public class GetEmployeeModel
    {
        public List<Dto.Employee> Employees { get; set; }
    }
}
