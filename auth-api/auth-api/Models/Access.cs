using System.ComponentModel.DataAnnotations;

namespace auth_api.Models;

public class Access
{
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string AccessToken { get; set; } = string.Empty;
    
    [Required]
    public DateTime AccessDateTime { get; set; } = DateTime.Now;
}