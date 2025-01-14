using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backoffice_api.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public long Id { get; set; }
    
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty; 
    
    [MaxLength(255)]
    public string Password { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    
    public Role Role { get; set; }
    
    [MaxLength(50)]
    public string Group { get; set; } = string.Empty;
    
    public Status Status { get; set; }
}