using Microsoft.EntityFrameworkCore;
using AccountingOfAchievements.Domain;
using AccountingOfAchievements.Domain.Model;

namespace AccountingOfAchievements.Infrastructure;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<Achievement> Achievements { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Achievement>()
            .ToTable("Achievements")
            .HasDiscriminator<string>("AchievementType")
            .HasValue<SportAchievement>("Sport")
            .HasValue<AcademicAchievement>("Academic")
            .HasValue<ArtAchievement>("Art");
    }
}