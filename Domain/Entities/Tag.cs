using System;
using NewBookApi.Services.ServiceInterfaces;

namespace NewBookApi.Domain.Entities;

public class Tag:IDifferentiateEntity
{
      public int TagId { get; set; }

      public string Name { get; set; } = null!;

      public ICollection<BookTag> BookTags { get; set; } = null!;
}
