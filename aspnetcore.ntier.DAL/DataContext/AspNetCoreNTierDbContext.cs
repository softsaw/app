using aspnetcore.ntier.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore.ntier.DAL.DataContext;

public class AspNetCoreNTierDbContext : DbContext
{
    public AspNetCoreNTierDbContext(DbContextOptions<AspNetCoreNTierDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User - Father ilişkisi (one-to-many)
        modelBuilder.Entity<User>()
            .HasOne(u => u.Father)
            .WithMany()
            .HasForeignKey("FatherId")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    
        // User - Mother ilişkisi (one-to-many)
        modelBuilder.Entity<User>()
            .HasOne(u => u.Mother)
            .WithMany()
            .HasForeignKey("MotherId")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    
        // User - Spouse ilişkisi (one-to-one)
        modelBuilder.Entity<User>()
            .HasOne(u => u.Spouse)
            .WithOne()
            .HasForeignKey<User>("SpouseId")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    
        // User - Children ilişkisi (one-to-many)
        modelBuilder.Entity<User>()
            .HasMany(u => u.Children)
            .WithOne()
            .HasForeignKey("ParentId")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    
        // User - Siblings ilişkisi (many-to-many)
        modelBuilder.Entity<User>()
            .HasMany(u => u.Siblings)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "UserSiblings",
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("SiblingId")
                    .OnDelete(DeleteBehavior.Restrict)
            );
            
        modelBuilder.Entity<User>().HasData(
             new User
             {
                 Id = 1,
                 Username = "emrahkocak",
                 Password = "123",
                 Name = "emrah",
                 Surname = "kocak",
             }
         );
    }
}