using aspnetcore.ntier.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore.ntier.DAL.DataContext;

public class AspNetCoreNTierDbContext : DbContext
{
    public AspNetCoreNTierDbContext(DbContextOptions<AspNetCoreNTierDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<UserSibling> UserSiblings { get; set; }
    public DbSet<UserPaternalUncle> UserPaternalUncles { get; set; }
    public DbSet<UserPaternalAunt> UserPaternalAunts { get; set; }
    public DbSet<UserMaternalUncle> UserMaternalUncles { get; set; }
    public DbSet<UserMaternalAunt> UserMaternalAunts { get; set; }
    public DbSet<UserCousin> UserCousins { get; set; }
    public DbSet<UserChild> UserChildren { get; set; }
    public DbSet<UserNephew> UserNephews { get; set; }
    public DbSet<UserGrandparent> UserGrandparents { get; set; }
    public DbSet<UserGrandchild> UserGrandchildren { get; set; }

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
    
        // UserSibling entity configuration
        modelBuilder.Entity<UserSibling>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.SiblingId });

            entity.HasOne(e => e.User)
                .WithMany(u => u.Siblings)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Sibling)
                .WithMany(u => u.SiblingOf)
                .HasForeignKey(e => e.SiblingId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // UserPaternalUncle entity configuration
        modelBuilder.Entity<UserPaternalUncle>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.UncleId });

            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Uncle)
                .WithMany()
                .HasForeignKey(e => e.UncleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // UserPaternalAunt entity configuration
        modelBuilder.Entity<UserPaternalAunt>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.AuntId });

            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Aunt)
                .WithMany()
                .HasForeignKey(e => e.AuntId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // UserMaternalUncle entity configuration
        modelBuilder.Entity<UserMaternalUncle>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.UncleId });

            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Uncle)
                .WithMany()
                .HasForeignKey(e => e.UncleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // UserMaternalAunt entity configuration
        modelBuilder.Entity<UserMaternalAunt>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.AuntId });

            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Aunt)
                .WithMany()
                .HasForeignKey(e => e.AuntId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // UserCousin entity configuration
        modelBuilder.Entity<UserCousin>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.CousinId });

            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Cousin)
                .WithMany()
                .HasForeignKey(e => e.CousinId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // UserChild entity configuration
        modelBuilder.Entity<UserChild>(entity =>
        {
            entity.HasKey(e => new { e.ParentId, e.ChildId });

            entity.HasOne(e => e.Parent)
                .WithMany()
                .HasForeignKey(e => e.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Child)
                .WithMany()
                .HasForeignKey(e => e.ChildId)
                .OnDelete(DeleteBehavior.Restrict);
        });
                        
        // UserNephew entity configuration
        modelBuilder.Entity<UserNephew>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.NephewId });

            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Nephew)
                .WithMany()
                .HasForeignKey(e => e.NephewId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // UserGrandparent entity configuration
        modelBuilder.Entity<UserGrandparent>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.GrandparentId });

            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Grandparent)
                .WithMany()
                .HasForeignKey(e => e.GrandparentId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // UserGrandchild entity configuration
        modelBuilder.Entity<UserGrandchild>(entity =>
        {
            entity.HasKey(e => new { e.GrandparentId, e.GrandchildId });

            entity.HasOne(e => e.Grandparent)
                .WithMany()
                .HasForeignKey(e => e.GrandparentId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Grandchild)
                .WithMany()
                .HasForeignKey(e => e.GrandchildId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Nephews ve Siblings arasındaki ilişki
        modelBuilder.Entity<User>()
            .HasMany(u => u.Nephews)
            .WithMany(u => u.Siblings)
            .UsingEntity<UserNephew>(
                j => j.HasOne(un => un.Nephew)
                    .WithMany()
                    .HasForeignKey(un => un.NephewId)
                    .OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne(un => un.User)
                    .WithMany()
                    .HasForeignKey(un => un.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
            );

        // Grandparents ve Children arasındaki ilişki
        modelBuilder.Entity<User>()
            .HasMany(u => u.Grandparents)
            .WithMany(g => g.Grandchildren)
            .UsingEntity<UserGrandparent>(
                j => j.HasOne(ug => ug.Grandparent)
                    .WithMany()
                    .HasForeignKey(ug => ug.GrandparentId)
                    .OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne(ug => ug.User)
                    .WithMany()
                    .HasForeignKey(ug => ug.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
            );

        // Kullanıcının siblings ilişkisi
        modelBuilder.Entity<User>()
            .HasMany(u => u.Siblings)
            .WithMany(s => s.Siblings)
            .UsingEntity<UserSibling>(
                j => j.HasOne(us => us.Sibling)
                    .WithMany()
                    .HasForeignKey(us => us.SiblingId)
                    .OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne(us => us.User)
                    .WithMany()
                    .HasForeignKey(us => us.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
            );

        // Kullanıcının cousins ilişkisi 
        modelBuilder.Entity<User>()
            .HasMany(u => u.Cousins)
            .WithMany(c => c.Cousins)
            .UsingEntity<UserCousin>(
                j => j.HasOne(uc => uc.Cousin)
                    .WithMany()
                    .HasForeignKey(uc => uc.CousinId)
                    .OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne(uc => uc.User)
                    .WithMany()
                    .HasForeignKey(uc => uc.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
            );

        // PaternalUncles ilişkisi
        modelBuilder.Entity<User>()
            .HasMany(u => u.PaternalUncles)
            .WithMany(u => u.PaternalNephews)
            .UsingEntity<UserPaternalUncle>(
                j => j.HasOne(upu => upu.Uncle)
                    .WithMany()
                    .HasForeignKey(upu => upu.UncleId)
                    .OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne(upu => upu.User)
                    .WithMany()
                    .HasForeignKey(upu => upu.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
            );

        // PaternalAunts ilişkisi
        modelBuilder.Entity<User>()
            .HasMany(u => u.PaternalAunts)
            .WithMany(a => a.PaternalNieces)
            .UsingEntity<UserPaternalAunt>(
                j => j.HasOne(upa => upa.Aunt)
                    .WithMany()
                    .HasForeignKey(upa => upa.AuntId)
                    .OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne(upa => upa.User)
                    .WithMany()
                    .HasForeignKey(upa => upa.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
            );

        // MaternalUncles ilişkisi
        modelBuilder.Entity<User>()
            .HasMany(u => u.MaternalUncles)
            .WithMany(u => u.MaternalNephews)
            .UsingEntity<UserMaternalUncle>(
                j => j.HasOne(umu => umu.Uncle)
                    .WithMany()
                    .HasForeignKey(umu => umu.UncleId)
                    .OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne(umu => umu.User)
                    .WithMany()
                    .HasForeignKey(umu => umu.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
            );

        // MaternalAunts ilişkisi
        modelBuilder.Entity<User>()
            .HasMany(u => u.MaternalAunts)
            .WithMany(a => a.MaternalNieces)
            .UsingEntity<UserMaternalAunt>(
                j => j.HasOne(uma => uma.Aunt)
                    .WithMany()
                    .HasForeignKey(uma => uma.AuntId)
                    .OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne(uma => uma.User)
                    .WithMany()
                    .HasForeignKey(uma => uma.UserId)
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
                 Email = "emrah@example.com",
                 BirthPlace = "Ankara",
                 Phone = "5551234567",
                 Job = "Yazılım Geliştirici",
                 Address = "Ankara, Türkiye",
                 Location = "Ankara",
                 Notes = "",
                 Education = "Lisans",
                 SocialMediaLinks = "",
                 ProfileImageUrl = "",
                 UserId = "1",
                 BirthDate = new DateTime(1990, 1, 1)
             }
         );
    }
}