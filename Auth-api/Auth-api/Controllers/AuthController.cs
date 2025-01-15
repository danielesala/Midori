using Auth_api.Dto;
using Auth_api.Service;
using Microsoft.AspNetCore.Mvc;
using MidoriCore.Entity;

namespace Auth_api.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthController(ILogger<AuthController> logger,IAuthService service) :ControllerBase
    {
        private readonly ILogger<AuthController> _logger = logger;
        private readonly IAuthService service = service;

        [HttpGet]
        public Task<IActionResult> Login(LoginDto dto)
        {
            return Task.FromResult<IActionResult>(Ok(service.Login(dto)));
        }
    }
}
