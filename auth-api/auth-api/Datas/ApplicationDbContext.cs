using auth_api.Models;
using Microsoft.EntityFrameworkCore;

namespace auth_api.Datas
{
    public class ApplicationDbContext(IConfiguration configuration) : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("SampleDbConnection"));
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        
        DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
