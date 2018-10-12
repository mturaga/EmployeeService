using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace EmployeeService.Controllers
{
    [Route("api/health-check")]
    [ApiController]
    public class HealthCheckController: Controller
    {
        [HttpGet]
        public IActionResult HealthCheck()
        {
            Log.Information("Log: Log.Information");
            Log.Warning("Log: Log.Warning");
            Log.Error("Log: Log.Error");
            Log.Fatal("Log: Log.Fatal");


            return Ok();
        }


        [HttpGet]
        [Route("Dummy")]
        public IActionResult Dummy()
        {

            return Ok();
        }
    }
}
