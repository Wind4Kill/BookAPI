using System;
using System.ComponentModel.DataAnnotations;

namespace NewBookApi.Services.DTOs;

public class BookAuthorDTO : IValidatableObject
{
      [Required]
      public int AuthorId { get; set; }

      [Required]
      public string Name { get; set; } = null!;

      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
            
            if (string.IsNullOrEmpty(Name) || Name.ToLower() == "string")
            {
                  yield return new ValidationResult("Author's name contains unappropriate value.", new[] { nameof(Name) });
            }
      }
}
