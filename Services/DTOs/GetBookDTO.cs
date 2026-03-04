using System;
using System.ComponentModel.DataAnnotations;

namespace NewBookApi.Services.DTOs;

public class GetBookDTO
{
      public int BookId { get; set; }
      public string Title { get; set; } = null!;
      public decimal Price { get; set; }

      public int PageNum { get; set; }
      bool IsAvailable { get; set; }
      public DateOnly PublishedOn { get; set; }
      public double? Rating { get; set; }
}
