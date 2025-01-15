using Auth_api.Data;
using Auth_api.Dto;
using MidoriCore.Entity;

namespace Auth_api.Service
{
    public class AuthService(AppDbContext appDbContext, ILogger<AuthService> logger) : IAuthService
    {
        private readonly AppDbContext appDbContext = appDbContext;
        private readonly ILogger<AuthService> logger = logger;

        public async Task<string> Login(LoginDto dto)
        {
            HttpClient httpClient = new HttpClient();
            User utente = await httpClient.GetFromJsonAsync<User>($"http://localhost:5000/users/email/{dto.Email}") ?? throw new Exception();
            return utente.Email;
        }
    }
}
