using System;

namespace NewBookApi.Domain.Entities;

public class Author
{

      public int AuthorId { get; set; }
      public string Name { get; set; } = null!;

      public List<Book> Books { get; set; } = new();
}
