using System;
using NewBookApi.Services.DTOs;

namespace NewBookApi.Services.ServiceInterfaces;

public interface IAuthorControlService
{
      Task<GetAuthorDetailsDTO?> GetAuthorById(int id);
      Task<List<GetAuthorDTO>?> GetAuthors();
}
