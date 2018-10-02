using EmployeeService.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Business.Clients
{
    public interface IEmployeeClient
    {
        Task<List<Employee>> GetEmployees();
    }
}
