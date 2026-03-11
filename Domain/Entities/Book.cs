using System;

namespace NewBookApi.Domain.Entities;

public class Book
{
      public int BookId { get; set; }

      public string Title { get; set; } = null!;

      public string Description { get; set; } = null!;

      public int Pages { get; set; }

      public int Capacity { get; set; }
      
      public BookCover Coverage { get; set; }

      public DateOnly PublishDate { get; set; }

      public decimal Price { get; set; }

      public List<Author> Authors { get; set; } = new();

      public bool IsDeleted { get; set; }

      public List<Review>? Reviews { get; set; } = new();

      public ICollection<BookTag> BookTags { get; set; } = null!;


}
