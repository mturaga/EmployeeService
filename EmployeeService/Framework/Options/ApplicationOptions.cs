using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Framework.Options
{
    public class ApplicationOptions
    {
        public PolicyOptions Policies { get; set; }

        public EmployeeClientOptions EmployeeClient { get; set; }
    }
}
