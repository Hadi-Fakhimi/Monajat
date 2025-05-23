using Microsoft.EntityFrameworkCore;
using Monajat.Core.Models;

namespace Monajat.Infra.Data.Context
{
    public class MonajatDbContext:DbContext
    {
        public MonajatDbContext(DbContextOptions<MonajatDbContext> options) : base(options)
        {

        }

        #region ChangeTraker

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker
                .Entries().
                Where(e => e.State == EntityState.Modified).ToList();

            foreach (var entry in entities)
            {
                if (entry.Entity is User user)
                {
                    user.UpdatedAt = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region Db Set
        public DbSet<User> Users { get; set; }
        public DbSet<AppVersion> AppVersions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<TextContent> TextContents { get; set; }
        public DbSet<Verse> Verses { get; set; }
        public DbSet<HomeLayout> HomeLayouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Audio> Audios { get; set; }
        public DbSet<Option> Options { get; set; }

        #endregion

        #region On Model Creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Uuid).IsRequired();
                entity.Property(e => e.MarketName).HasMaxLength(15);
                entity.Property(e => e.FirebaseId).HasMaxLength(255);
                entity.Property(e => e.LanguageCode).HasMaxLength(4);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<AppVersion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.VersionCode).HasColumnType("int");
                entity.Property(e => e.VersionName).HasMaxLength(20).IsUnicode();
                entity.Property(e => e.Changelog).HasColumnType("nvarchar(max)");
            });



            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RowId).HasColumnType("int");
                entity.Property(e => e.Title).HasMaxLength(80).IsUnicode();
                entity.Property(e => e.Type).HasConversion<string>();
                entity.Property(e => e.Description).HasColumnType("nvarchar(max)");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ArabicText).HasColumnType("nvarchar(max)");
                entity.Property(e => e.PersianText).HasColumnType("nvarchar(max)");
            });

            modelBuilder.Entity<TextContent>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Text).HasColumnType("nvarchar(max)");
            });

            modelBuilder.Entity<Verse>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ArabicText).HasColumnType("nvarchar(max)");
                entity.Property(e => e.PersianText).HasColumnType("nvarchar(max)");
                entity.Property(e => e.Reference).HasMaxLength(150).IsUnicode();
            });

            modelBuilder.Entity<HomeLayout>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Type).HasMaxLength(15);
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).HasMaxLength(100).IsUnicode();
                entity.Property(e => e.ImageUrl).HasMaxLength(150).IsUnicode();
                entity.Property(e => e.Place).HasMaxLength(10);
            });

            modelBuilder.Entity<Audio>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(80).IsUnicode();
                entity.Property(e => e.AudioLink).HasMaxLength(150).IsUnicode();
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Key).HasMaxLength(50).IsUnicode();
                entity.Property(e => e.Value).HasColumnType("nvarchar(max)");
            });
        }

        #endregion

    }
}
