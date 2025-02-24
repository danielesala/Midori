using System.ComponentModel.DataAnnotations;

namespace auth_api.Dtos
{
    public class LoginInDto
    {
        [Required (AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;
        
        [Required (AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
    }
}
