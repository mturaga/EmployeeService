using MediatR;
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
        private IMediator _mediator;
        public BaseController( ILogger logger, IMediator mediator)
        {
           
            _logger = logger;
            _mediator = mediator;
        }
       
        public ILogger Logger { get { return _logger; } }
        public IMediator Mediator { get { return _mediator; } }


    }
}
