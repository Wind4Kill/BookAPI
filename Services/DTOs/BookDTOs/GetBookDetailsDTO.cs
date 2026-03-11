using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using NewBookApi.Domain.Entities;

namespace NewBookApi.Services.DTOs;

[AutoMap(typeof(Book))]
public class GetBookDetailsDTO
{
      public int BookId { get; set; }
      public string Title { get; set; } = null!;
      public decimal Price { get; set; }

      public string Description { get; set; } = null!;

      public int Pages { get; set; }

      public bool IsAvailable { get; set; }

      public BookCover Coverage { get; set; }

      public DateOnly PublishDate { get; set; }
      public List<AuthorDTO> Authors { get; set; } = new();

      public ICollection<string> BookTags { get; set; } = null!;
}
