using System;
using System.ComponentModel.DataAnnotations;
using NewBookApi.Domain.Entities;

namespace NewBookApi.Services.DTOs;

public class GetBookDetailsDTO
{
      public int BookId { get; set; }
      public string Title { get; set; } = null!;
      public decimal Price { get; set; }

      public string Description { get; set; } = null!;

      public int Pages { get; set; }

      public bool IsAvailable { get; set; }

      public BookCover Coverage { get; set; }

      public DateOnly PublishedOn { get; set; }
      public List<BookAuthorDTO> Authors { get; set; } = new();
}
