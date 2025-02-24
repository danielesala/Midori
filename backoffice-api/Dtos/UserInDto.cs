using System.ComponentModel.DataAnnotations;
using backoffice_api.Models;

namespace backoffice_api.Dtos;

public class UserInDto
{
    [MaxLength(50, ErrorMessage = "Email cannot be more than 50 characters")]
    [Required (ErrorMessage = "Email is required")]
    public string Email { get; set; } = string.Empty;
    
    [Required (ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
    
    [MaxLength(50, ErrorMessage = "Username cannot be more than 50 characters")]
    [Required (ErrorMessage = "Username is required")]
    public string UserName { get; set; } = string.Empty;
    
    [MaxLength(50, ErrorMessage = "FirstName cannot be more than 50 characters")]
    [Required (ErrorMessage = "FirstName is required")]
    public string FirstName { get; set; } = string.Empty;
    
    [MaxLength(50, ErrorMessage = "LastName cannot be more than 50 characters")]
    [Required (ErrorMessage = "LastName is required")]
    public string LastName { get; set; } = string.Empty;
    
    public string Role { get; set; } = string.Empty;
    
    [Required (ErrorMessage = "Group is required")]
    public string Group  { get; set; } = string.Empty;
    
    [Required (ErrorMessage = "Status is required")]
    public string Status { get; set; } = string.Empty;
}