using Auth_api.Dto;

namespace Auth_api.Service
{
    public interface IAuthService
    {
        public string Login(LoginDto dto);
    }
}
