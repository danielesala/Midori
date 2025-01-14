using backoffice_api.Dtos;

namespace backoffice_api.Services;

public interface IUserService
{
    List<UserOutDto> GetUsers();
    
    UserOutDto GetUserById(int id);
    
    UserOutDto Create(UserInDto user);
    
    UserOutDto Update(int id, UserInDto user);
    
    void Delete(int id);
    
    UserOutDto GetUserByEmail(string email);
}