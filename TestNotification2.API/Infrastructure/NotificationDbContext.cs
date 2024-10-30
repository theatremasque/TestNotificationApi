using Microsoft.EntityFrameworkCore;
using TestNotification2.API.Entities;

namespace TestNotification2.API.Infrastructure;

public class NotificationDbContext : DbContext
{
    public NotificationDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<PublicationNotification> PublicationNotifications { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<PublicationNotification>()
            .HasIndex(e => e.PublicationId)
            .IsUnique();*/
        
        base.OnModelCreating(modelBuilder);
    }
}