using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBookApi.Domain.Entities;

namespace NewBookApi.Domain.EntityConfiguration;

public class BookReviewConfiguration : IEntityTypeConfiguration<Review>
{
      public void Configure(EntityTypeBuilder<Review> builder)
      {
            builder.HasOne(r => r.Book).WithMany(b => b.Reviews).HasForeignKey(r => r.BookId);
      }
}
