using backoffice_api.Models;

namespace backoffice_api.Dtos;

public class UserOutDto
{
    public long Id { get; set; }
    
    public string Email { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;
    
    public string Username { get; set; } = string.Empty;
    
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public string Role { get; set; } = string.Empty;
    
    public string Status { get; set; } = string.Empty;
    
    public string Group { get; set; } = string.Empty;

    public static UserOutDto Build(User user)
    {
        
        //creating user out dto
        UserOutDto output = new UserOutDto();
        output.Id = user.Id;
        output.Email = user.Email;
        output.Password = user.Password;
        output.Username = user.Username;
        output.FirstName = user.FirstName;
        output.LastName = user.LastName;
        output.Role = user.Role.ToString();
        output.Status = user.Status.ToString();
        output.Group = user.Group;
        
        return output;
    }
}