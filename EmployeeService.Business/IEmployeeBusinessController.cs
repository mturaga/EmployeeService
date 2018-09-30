using EmployeeService.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Business
{
    public interface IEmployeeBusinessController
    {
        Task<List<Employee>> GetEmployeesAsync(int skip = 0, int limit=25);
    }
}
