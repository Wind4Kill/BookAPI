using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using NewBookApi.Domain.Entities;

namespace NewBookApi.Services.DTOs;

[AutoMap(typeof(Book))]
public class GetBookDTO
{
      public int BookId { get; set; }
      public string Title { get; set; } = null!;
      public decimal Price { get; set; }

      public int Pages { get; set; }
      bool IsAvailable { get; set; }
      public DateOnly PublishDate { get; set; }
      public double? Rating { get; set; }
      public ICollection<BookTag> BookTags { get; set; } = null!;
}
