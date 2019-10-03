using BookCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogAPI.Data
{
    public class BookCatalogContext : DbContext
    {
        public BookCatalogContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookStock> BookStocks { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>(ConfigureBookCategory);
            modelBuilder.Entity<Book>(ConfigureBook);
            modelBuilder.Entity<BookStock>(ConfigureBookStock);
            modelBuilder.Entity<BookAuthor>(ConfigureBookAuthor);
        }

        private void ConfigureBookAuthor(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.ToTable("BookAuthors");
            builder.Property(a => a.Id).IsRequired().ForSqlServerUseSequenceHiLo("book_author_hilo");
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
        }

        private void ConfigureBookStock(EntityTypeBuilder<BookStock> builder)
        {
            builder.ToTable("BookStocks");
            builder.Property(s => s.Id).IsRequired().ForSqlServerUseSequenceHiLo("book_stock_hilo");
            builder.Property(s => s.BookId).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Quantity).IsRequired().HasMaxLength(100);
        }

        private void ConfigureBook(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.Property(b => b.Id).IsRequired().ForSqlServerUseSequenceHiLo("book_hilo");
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Description).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Price).IsRequired();
            builder.Property(b => b.ISBN).IsRequired().HasMaxLength(100);
            builder.Property(b => b.PublishedDate).IsRequired();

            builder.HasOne(b => b.BookCategory).WithMany().HasForeignKey(b => b.BookCategoryId);
            builder.HasOne(b => b.BookAuthor).WithMany().HasForeignKey(b => b.BookAuthorId);
            builder.HasOne(b => b.BookStock).WithMany().HasForeignKey(b => b.BookStockId);

        }

        private void ConfigureBookCategory(EntityTypeBuilder<BookCategory> builder)
        {
            builder.ToTable("BookCategories");
            builder.Property(c => c.Id).IsRequired().ForSqlServerUseSequenceHiLo("book_category_hilo");
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(100);
        }
    }
}
