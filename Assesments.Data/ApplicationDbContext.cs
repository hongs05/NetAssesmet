using Microsoft.EntityFrameworkCore;

namespace Assesments.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Assesment> Assesments { get; set; }
    public DbSet<Priority> Priorities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships if needed
        modelBuilder.Entity<Assesment>()
            .HasOne(t => t.User)
            .WithMany(u => u.Assesments)
            .HasForeignKey(t => t.UserId);

        modelBuilder.Entity<Assesment>()
            .HasOne(t => t.Priority)
            .WithMany(p => p.Assesments)
            .HasForeignKey(t => t.PriorityId);
    }

}
