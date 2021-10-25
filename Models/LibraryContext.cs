using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace TodoApi.Models
{
    public class LibraryContext : IdentityDbContext<UserEntity>
    {
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<BookEntity> BookEntities { get; set; }
        public DbSet<ShelfEntity> ShelfEntities { get; set; }
        public DbSet<BookShelves> BookShelves { get; set; }


        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BookEntity>(e =>
           {
               e.HasKey(p => p.Id);
               e.ToTable("BookEntities");
           });
            builder.Entity<BookShelves>(e =>
           {
               e.HasKey(p => p.Id);
               e.HasOne(x => x.bookEntity).WithMany(x => x.BookShelves).HasForeignKey(x => x.BookId);
               e.ToTable("BookShelves");
           });

            builder.Entity<UserEntity>(e =>
           {
               e.HasKey(X => X.Id);
               e.ToTable("UserEntities");
           });
            builder.Entity<ShelfEntity>(e =>
           {
               e.HasKey(X => X.Id);
               e.HasOne(x => x.user).WithMany(x => x.UserShelf).HasForeignKey(x => x.UserId);
               e.HasMany(x => x.BookShelves).WithOne(x => x.ShelfEntity).HasForeignKey(x => x.ShelfId);
               e.ToTable("shelves");
           });

        }




    }
}
