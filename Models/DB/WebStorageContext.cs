using Microsoft.EntityFrameworkCore;

namespace Balkhanakovv.WebStorage.Models.DB
{
    public class WebStorageContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<DocumentType> Types { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<MemoryRate> Rates { get; set; }

        public WebStorageContext(DbContextOptions<WebStorageContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            builder.Entity<Group>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            builder.Entity<DocumentType>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            builder.Entity<Document>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            builder.Entity<MemoryRate>(entity =>
            {
                entity.HasIndex(e => e.Size).IsUnique();
            });
        }
    }
}
