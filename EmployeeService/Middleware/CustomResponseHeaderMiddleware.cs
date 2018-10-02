using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Middleware
{
    public class CustomResponseHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomResponseHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {

            context.Response.Headers["X-PAYCOR-CUSTOM"] = Guid.NewGuid().ToString();

            // Call the next delegate/middleware in the pipeline
            return this._next(context);
        }
    }
}
