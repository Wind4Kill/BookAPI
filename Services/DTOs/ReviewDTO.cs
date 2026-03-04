using System;
using System.ComponentModel.DataAnnotations;

namespace NewBookApi.Services.DTOs;

public class ReviewDTO
{
      [Required]
      public int ReviewId { get; set; }


      public string? Description { get; set; }

      [Required]
      [Range(minimum:0,maximum:5)]
      public int Stars { get; set; }
}
