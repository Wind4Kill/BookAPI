using System;
using NewBookApi.Domain.Entities;

namespace NewBookApi.Services.DTOs;

using static System.Console;

public static class BookExtensions
{
      public static IQueryable<GetBookDTO> OrderQuery(this IQueryable<GetBookDTO> books, SortingOptions options)
      {
            switch (options)
            {
                  case SortingOptions.Id:
                        {
                              return books.OrderBy(b => b.BookId);
                        }
                  case SortingOptions.Rating:
                        {
                              return books.OrderByDescending(b => b.Rating);
                        }
                  case SortingOptions.PublishDate:
                        {
                              return books.OrderByDescending(b => b.PublishedOn);
                        }
                  case SortingOptions.Price:
                        {
                              return books.OrderBy(b => (double)b.Price);
                        }
                  case SortingOptions.PageNum:
                        {
                              return books.OrderBy(b => b.PageNum);
                        }
                  default: throw new ArgumentException("Sorting is required.");
            }
      }

      public static IQueryable<GetBookDTO> FilterQuery(this IQueryable<GetBookDTO> books, FilterOptions options, int filterValue)
      {
            return options switch

            {
                  FilterOptions.None => books,
                  FilterOptions.Rating => books.Where(b => b.Rating > filterValue),
                  FilterOptions.Price => books.Where(b => b.Price <= filterValue),
                  FilterOptions.PageNum => books.Where(b => b.PageNum <= filterValue),
                  _ => books
            };
      }

      public static IQueryable<GetBookDTO> Page(this IQueryable<GetBookDTO> books, int page, int pageSize)
      {
            if (page < 1)
            {
                  page = 1;
            }
            if (pageSize < 10)
            {
                  pageSize = 10;
            }

            return books.Skip(page - 1 * pageSize).Take(pageSize);
      }
}
