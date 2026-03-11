using System;
using System.ComponentModel.DataAnnotations;
using NewBookApi.Domain.Entities;
using NewBookApi.Services.ServiceInterfaces;

namespace NewBookApi.Services.DTOs;

public class UpdateBookDTO
{
      [Required]
      public int BookId { get; set; }

      [MinLength(3)]
      [MaxLength(300)]
      public string? Title { get; set; } = null!;

      public decimal? Price { get; set; }

      [MaxLength(1000)]
      public string? Description { get; set; } = null!;
      public int? Pages { get; set; }
      public int? BookCapacity { get; set; }

      public BookCover? Coverage { get; set; }

      [Required]
      public List<string>? Authors { get; set; } = new();

      [Required]
      public ICollection<string>? Tags { get; set; } = null!;

}
