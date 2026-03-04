using System;
using System.ComponentModel.DataAnnotations;
using NewBookApi.Domain.Entities;

namespace NewBookApi.Services.DTOs;

public class UpdateBookDTO : IValidatableObject
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

      public List<BookAuthorDTO>? Authors { get; set; } = new();

      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
            if (Title is not null && Title.ToLower() == "string")
            {
                  yield return new ValidationResult("Title has an unappropriate value", new[] { nameof(Title) });
            }

            if (Description is not null && Description.ToLower() == "string")
            {
                  yield return new ValidationResult("Description has an unappropriate value", new[] { nameof(Description) });
            }

            if (Price < 0 || Price > 10000)
            {
                  yield return new ValidationResult("Price can't be less than 0 and higher than 10000", [nameof(Price)]);
            }

            if (Pages < 0 || Pages > 3000)
            {
                  yield return new ValidationResult("Pages amount can't be less than zero or higher than 3000", [nameof(Pages)]);
            }

            if (BookCapacity < 0 && BookCapacity > int.MaxValue)
            {
                  yield return new ValidationResult("Books capacity can't include the entered value.", [nameof(BookCapacity)]);
            }
            
      }
}
