using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeService.Common
{
    public class AppSettings : IAppSettings
    {
        public int DefaultPageSize { get; set; }
        public int MaxPageSize { get; set; }
        public List<UrlItem> DomainUrls { get; set; }
    }
}
