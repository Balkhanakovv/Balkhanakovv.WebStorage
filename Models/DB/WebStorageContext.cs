using Microsoft.EntityFrameworkCore;

namespace Balkhanakovv.WebStorage.Models.DB
{
    public class WebStorageContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<DocumentType> Types { get; set; } = null!;
        public DbSet<Document> Documents { get; set; } = null!;
        public DbSet<MemoryRate> Rates { get; set; } = null!;

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

            builder.Entity<Group>().HasData(
                new Group { Id = 1, Name = "Administrator" },
                new Group { Id = 2,Name = "SimpleUser" }
            );

            builder.Entity<DocumentType>().HasData(
                new DocumentType { Id = 1, Name = "Text document" },
                new DocumentType { Id = 2, Name = "Image" },
                new DocumentType { Id = 3, Name = "Binary" }
            );

            builder.Entity<MemoryRate>().HasData(
                new MemoryRate { Id = 1, Size = 100 },
                new MemoryRate { Id = 2, Size = 300 },
                new MemoryRate { Id = 3, Size = 500 }
            );

            builder.Entity<User>().HasData(
                new User { Id = 1, Name = "admin", FullName = "Администратор системы", GroupId = 1, Password = "admin", RateId = 3 },
                new User { Id = 2, Name = "user", FullName = "Пользователь системы", GroupId = 2, Password = "123456", RateId = 3 }
            );
        }
    }
}
