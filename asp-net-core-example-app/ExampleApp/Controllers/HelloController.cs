using Microsoft.AspNetCore.Mvc;

namespace ExampleApp.Controllers
{
    [ApiController]
    public class HelloController : Controller
    {
        [HttpGet("")]
        public IActionResult GetMyIp()
        {
            string clientIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            string response = $"Hello. Your IP address is: {clientIp}";
            return Ok(response);
        }
    }
}
