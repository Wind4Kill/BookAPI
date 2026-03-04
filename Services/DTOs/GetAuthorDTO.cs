using System;
using System.ComponentModel.DataAnnotations;
using NewBookApi.Domain.Entities;

namespace NewBookApi.Services.DTOs;

public class GetAuthorDTO
{

      [Required]
      public int AuthorId { get; set; }

      [Required]
      public string Name { get; set; } = null!;

}
