using System;
using NewBookApi.Services.DTOs;

namespace NewBookApi.Services.ServiceInterfaces;

public interface IBooksControlService
{
      Task<int> AddBook(CreateBookDTO bookDTO);
      Task<GetBookDetailsDTO?> GetBookById(int id);
      Task<List<GetBookDTO>> GetBooks(SortFilterOptions options);
      Task<int> RemoveBook(int Id);
      Task<int> UpdateBook(UpdateBookDTO bookDto);
}