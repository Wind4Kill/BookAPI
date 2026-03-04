using System;

namespace NewBookApi.Services.DTOs;

public class GetAuthorDetailsDTO
{
      public int AuthorId { get; set; }

      public string Name { get; set; } = null!;

      public List<GetBookDTO> Books { get; set; } = new();
}
