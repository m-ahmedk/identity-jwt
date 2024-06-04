using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace identity_jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await Task.FromResult(new string[] { "ahmed", "adam", "bob" });
            return Ok(employees);
        }

        [Route("test-anonymous")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> TestAnonymous()
        {
            return Ok("This is accessible to public");
        }

        [Authorize(Roles = "Admin")]
        [Route("test-admin")]
        [HttpGet]
        public async Task<IActionResult> TestAdmin()
        {
            return Ok("This is accessible to public");
        }
    }
}
