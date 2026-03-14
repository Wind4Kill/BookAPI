using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBookApi.Domain.Entities;

namespace NewBookApi.Domain.EntityConfiguration;

public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
{
      public void Configure(EntityTypeBuilder<Book> builder)
      {
            builder.HasMany(b => b.Authors).WithMany(a => a.Books);
            builder.Property(b => b.Coverage).HasConversion<string>();
      }
}
