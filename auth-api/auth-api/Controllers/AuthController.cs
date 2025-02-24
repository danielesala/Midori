using auth_api.Clients;
using auth_api.Dtos;
using auth_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace auth_api.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController(IAuthService authService, BackOfficeClient backOfficeClient) : ControllerBase
    {
        
        private readonly IAuthService _authService = authService;
        private readonly BackOfficeClient _backOfficeClient = backOfficeClient;

        [HttpPost]
        [Route("login")]
        public Task<IActionResult> Login(LoginInDto loginInDto)
        {
            return Task.FromResult<IActionResult>(Ok(_authService.GenerateJwtToken(loginInDto.Email, loginInDto.Password)));
        }

        [HttpGet]
        public IActionResult GetUser()
        {

            return Ok(_backOfficeClient.GetUserByIdAsync(1));
        }
    }
}
