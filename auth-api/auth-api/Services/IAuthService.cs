namespace auth_api.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string password);
    }
}
