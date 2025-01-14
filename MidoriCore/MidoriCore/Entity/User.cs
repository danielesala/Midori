namespace MidoriCore.Entity;

public class User
{
    public long Id { get; set; }
    
    public string Email { get; set; } = string.Empty; 
    
    public string Password { get; set; } = string.Empty;
    
    public string Username { get; set; } = string.Empty;
    
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public Role Role { get; set; }
    
    public string Group { get; set; } = string.Empty;
    
    public Status Status { get; set; }
}