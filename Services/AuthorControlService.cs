using System;
using Microsoft.EntityFrameworkCore;
using NewBookApi.Domain;
using NewBookApi.Services.DTOs;
using NewBookApi.Services.ServiceInterfaces;

namespace NewBookApi.Services;

public class AuthorControlService : IAuthorControlService
{

      ApplicationContext _dbContext;

      public AuthorControlService(ApplicationContext context)
      {
            _dbContext = context;
      }

      public async Task<List<GetAuthorDTO>?> GetAuthors()
      {
            return await _dbContext.Authors.Select(a => new GetAuthorDTO
            {
                  AuthorId = a.AuthorId,
                  Name = a.Name
            }).AsNoTracking().ToListAsync();
      }

      public async Task<GetAuthorDetailsDTO?> GetAuthorById(int id)
      {
            return await _dbContext.Authors.Where(a => a.AuthorId == id).Select(a => new GetAuthorDetailsDTO
            {
                  AuthorId = a.AuthorId,
                  Books = a.Books.Select(b => new GetBookDTO
                  {
                        BookId = b.BookId,
                        PageNum = b.Pages,
                        Price = b.Pages,
                        PublishedOn = b.PublishDate,
                        Title = b.Title,
                        Rating = b.Reviews!.Average(r => (double)r.Stars)
                  }).ToList()

            }).FirstOrDefaultAsync();
      }


}
