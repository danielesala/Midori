using auth_api.Models;
using Microsoft.EntityFrameworkCore;

namespace auth_api.Datas
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
