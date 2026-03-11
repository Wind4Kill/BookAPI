using System;

namespace NewBookApi.Domain.Entities;

public class BookTag
{
      public int BookId { get; set; }

      public int TagId { get; set; }

      public Book Book { get; set; } = null!;

      public Tag Tag { get; set; } = null!;
}
