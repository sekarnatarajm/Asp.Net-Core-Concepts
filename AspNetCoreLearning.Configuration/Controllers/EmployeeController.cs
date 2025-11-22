using AspNetCoreLearning.Configuration.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCoreLearning.Configuration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController (IOptions<MySettings> options, ISmtpSettings smtpSettings) : ControllerBase
    {
        [HttpGet("getsmtp/setting")]
        public IActionResult GetSmtpSetting()
        {
            var dd = smtpSettings.GetUserName();
            return Ok(options.Value);
        }
    }
}
