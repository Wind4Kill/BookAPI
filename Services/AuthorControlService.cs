using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NewBookApi.Domain;
using NewBookApi.Services.DTOs;
using NewBookApi.Services.ServiceInterfaces;

namespace NewBookApi.Services;

public class AuthorControlService : IAuthorControlService
{

      IMapper _mapper;
      ApplicationContext _dbContext;

      public AuthorControlService(ApplicationContext context, IMapper mapper)
      {
            _dbContext = context;
            _mapper = mapper;
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

            return await _dbContext.Authors.Where(a => a.AuthorId == id).
            ProjectTo<GetAuthorDetailsDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
      }


}
