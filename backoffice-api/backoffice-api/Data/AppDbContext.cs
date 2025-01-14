using Microsoft.EntityFrameworkCore;
using backoffice_api.Models;

namespace backoffice_api.Data;

public class AppDbContext(IConfiguration configuration) : DbContext
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
        modelBuilder.Entity<User>()
            .Property(u => u.Status)
            .HasConversion(
                v => v.ToString(), 
                v => (Status)Enum.Parse(typeof(Status), v) 
            );

        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion(
                v => v.ToString(),
                v => (Role)Enum.Parse(typeof(Role), v)
            );
    }

    public DbSet<User> Users { get; set; }
}