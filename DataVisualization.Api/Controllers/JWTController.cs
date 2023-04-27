using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataVisualization.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        public IActionResult Login(string userName, string password)
        {
            return Ok(true);
        }
        public IActionResult GetToken(string userName, string password)
        {
            bool isSuccess = false;
            if (!isSuccess)
            {
                return Ok("token");
            }
            return BadRequest();
        }
    }
}
