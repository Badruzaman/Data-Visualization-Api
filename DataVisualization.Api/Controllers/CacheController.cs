using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Security.Cryptography.X509Certificates;

namespace DataVisualization.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        [HttpGet("DateTime1")]
        [OutputCache]
        public IActionResult GetDateTime1()
        {
           return Ok(DateTime.Now);
        }
        [HttpGet("DateTime2")]
        [OutputCache(PolicyName ="custom")]
        public IActionResult GetDateTime2()
        {
            return Ok(DateTime.Now);
        }
    }
}
