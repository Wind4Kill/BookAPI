using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using NewBookApi.Domain.Entities;

namespace NewBookApi.Services.DTOs;

[AutoMap(typeof(Author))]
public class AuthorDTO
{
      [Required]
      public int AuthorId { get; set; }

      [Required]
      public string Name { get; set; } = null!;

}
