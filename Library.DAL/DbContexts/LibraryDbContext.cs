using Library.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.DbContexts
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new BookConfiguration())
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .Property(p => p.Title).IsRequired();
            modelBuilder.Entity<Book>()
                .Property(p => p.Author).IsRequired();
            modelBuilder.Entity<Book>()
                .Property(p => p.ISBN).IsRequired();

            modelBuilder.Entity<Book>().HasIndex(p => p.ISBN).IsUnique();
            modelBuilder.Entity<User>().HasIndex(p => p.Email).IsUnique();
        }

    }
}
