using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace auth_api.Models
{
    [Table(nameof(RefreshToken))]
    [Index(nameof(Token), IsUnique = true)]
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Token { get; set; } = null!;
        
        [Required]
        public DateTime CreationTime { get; set; }
        
        [Required]
        public DateTime ExpireTime { get; set; }
        
        [Required]
        public int UserId { get; set; }

    }
}
