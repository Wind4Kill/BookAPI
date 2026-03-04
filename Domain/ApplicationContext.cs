using System;
using Microsoft.EntityFrameworkCore;
using NewBookApi.Domain.Entities;
using NewBookApi.Domain.EntityConfiguration;

namespace NewBookApi.Domain;

public class ApplicationContext : DbContext
{

      public DbSet<Book> Books { get; set; }

      public DbSet<Author> Authors { get; set; }

      public DbSet<Review> Reviews { get; set; }


      public ApplicationContext(DbContextOptions options) : base(options) { }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
            modelBuilder.ApplyConfiguration<Review>(new BookReviewConfiguration());
            modelBuilder.ApplyConfiguration<Book>(new BookEntityConfiguration());
      }

}
