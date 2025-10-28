using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DigitalLibrary.WebApi.Models
{
    public class DigitalLibraryAppDbContext : DbContext

    {
        public DigitalLibraryAppDbContext(DbContextOptions<DigitalLibraryAppDbContext> options) : base(options) 
        { 
        

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Rating> Rating { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.userId)
                .IsRequired();

                entity.Property(u => u.name)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(u =>u.lastName)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(u => u.password)
                .IsRequired() 
                .HasMaxLength(255);

                entity.Property(u => u.email) 
                .IsRequired()
                .HasMaxLength(255);
            });

            modelBuilder.Entity<Book>(entity =>
            {

                entity.Property(b => b.id)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(b => b.title)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(b => b.author)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(b => b.yearPublication)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(b => b.coverImage)
                .IsRequired()
                .HasMaxLength(255);

                entity.HasOne(b => b.user)
                .WithMany(u => u.collection)
                .HasForeignKey(b => b.userId)
                .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(r => r.id)
               .IsRequired()
               .HasMaxLength(255);

                entity.Property(r => r.raiting)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(r => r.review)
                .IsRequired()
                .HasMaxLength(255);

                entity.HasOne(r => r.user)
                .WithMany()
                .HasForeignKey(r => r.userId)
                .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(r => r.book)
                .WithMany()
                .HasForeignKey(r => r.bookId)
                .OnDelete(DeleteBehavior.SetNull);
            });

        }
    }
}
