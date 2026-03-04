using System;

namespace NewBookApi.Domain.Entities;

public class Review
{
      public int ReviewId { get; set; }

      public int Stars { get; set; }

      public int BookId { get; set; }

      public Book Book { get; set; } = null!;

      public string? Description { get; set; }
}
