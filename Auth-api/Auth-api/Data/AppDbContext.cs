using Microsoft.EntityFrameworkCore;

namespace Auth_api.Data
{
    public class AppDbContext(IConfiguration configuration) : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("SampleDbConnection"));
            }
        }
    }
}
