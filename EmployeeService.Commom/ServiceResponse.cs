using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeService.Common
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
    }
}
