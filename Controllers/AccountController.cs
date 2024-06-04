using identity_jwt.Interfaces;
using identity_jwt.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace identity_jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountRepository accountRepository, ILogger<AccountController> logger)
        {
            _accountRepository = accountRepository;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO logindto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Payload is invalid");

                var response = await _accountRepository.LoginAccount(logindto);

                if (response == null) return BadRequest(response.Message);

                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterDTO registerdto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Payload is invalid");

                var response = await _accountRepository.RegisterAccount(registerdto);

                if(response.Message == null) return BadRequest(response.Message);

                return CreatedAtAction(nameof(Register), registerdto);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
