using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeService.Common
{
    public interface IAppSettings
    {
        int DefaultPageSize { get; set; }
        int MaxPageSize { get; set; }
        List<UrlItem> DomainUrls { get; set; }
        string EmployeeDataServiceUrl { get; set; }
    }

    public class UrlItem
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string HandShakeKey { get; set; }
    }
}
