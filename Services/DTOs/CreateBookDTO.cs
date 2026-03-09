using System;
using System.ComponentModel.DataAnnotations;
using NewBookApi.Domain.Entities;

namespace NewBookApi.Services.DTOs;

public class CreateBookDTO
{
      [Required]
      [MinLength(3)]
      [MaxLength(300)]
      public string Title { get; set; } = null!;

      [Required]
      [Range(0,5000)]
      public decimal Price { get; set; }

      [Required]
      [MaxLength(1000)]
      public string Description { get; set; } = null!;

      [Required]
      [Range(0, 3000)]
      public int Pages { get; set; }

      [Required]
      public int BookCapacity { get; set; }

      [Required]
      public BookCover Coverage { get; set; }

      [Required]
      [DataType(DataType.Date)]
      public DateOnly PublishedOn { get; set; }
      
      [Required]
      public List<AuthorDTO> Authors { get; set; } = new();

}
