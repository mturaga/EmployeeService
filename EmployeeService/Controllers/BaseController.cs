using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger _logger;
        public BaseController( ILogger logger)
        {
           
            _logger = logger;
        }
       
        public ILogger Logger { get { return _logger; } }
    }
}
