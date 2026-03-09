using System;
using AutoMapper;
using NewBookApi.Domain.Entities;

namespace NewBookApi.Services.DTOs;

[AutoMap(typeof(Author))]
public class GetAuthorDetailsDTO
{
      public int AuthorId { get; set; }

      public string Name { get; set; } = null!;

      public List<GetBookDTO> Books { get; set; } = new();
}
