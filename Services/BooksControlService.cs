using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NewBookApi.Domain;
using NewBookApi.Domain.Entities;
using NewBookApi.Services.DTOs;
using NewBookApi.Services.ServiceInterfaces;

namespace NewBookApi.Services;

public class BooksControlService : IBooksControlService
{
      ApplicationContext _dbContext = null!;
      IMapper _mapper;

      public BooksControlService(ApplicationContext context, IMapper mapper)
      {
            _dbContext = context;
            _mapper = mapper;

      }

      public async Task<List<GetBookDTO>> GetBooks(SortFilterOptions options)
      {
            return await _dbContext.Books.Where(b => b.Capacity > 0 == true && b.IsDeleted == false).AsNoTracking().
            ProjectTo<GetBookDTO>(_mapper.ConfigurationProvider).
            FilterQuery(options.Filtering, options.FilterValue).
            OrderQuery(options.Sorting).Page(page: options.PageNumber, pageSize: 10).
            ToListAsync();
      }

      public async Task<GetBookDetailsDTO?> GetBookById(int id)
      {
            return await _dbContext.Books.Where(b => b.IsDeleted == false && b.BookId == id).
            ProjectTo<GetBookDetailsDTO>(_mapper.ConfigurationProvider)
            .AsNoTracking().FirstOrDefaultAsync();
      }

      public async Task<int> AddBook(CreateBookDTO bookDTO)
      {
            List<Author> authors = await DifferentiateEntity<Author>(bookDTO.Authors);
            List<Tag> tags = await DifferentiateEntity<Tag>(bookDTO.Tags); 

            Book newBook = new()
            {
                  Title = bookDTO.Title,
                  Capacity = bookDTO.BookCapacity,
                  Description = bookDTO.Description,
                  Pages = bookDTO.Pages,
                  Coverage = bookDTO.Coverage,
                  PublishDate = bookDTO.PublishDate,
                  Price = bookDTO.Price,
                  Authors = authors,
                  BookTags = new List<BookTag>()
            };

            foreach (Tag tag in tags)
            {
                  newBook.BookTags.Add(new BookTag()
                  {
                        Book = newBook,
                        Tag = tag
                  });
            }

            _dbContext.Books.Add(newBook);
            return await _dbContext.SaveChangesAsync();
      }

      public async Task<int> RemoveBook(int Id)
      {
            Book? requiredBook = await _dbContext.Books.Where(b => b.BookId == Id).FirstOrDefaultAsync();

            if (requiredBook is not null)
            {
                  requiredBook.IsDeleted = true;
            }

            return await _dbContext.SaveChangesAsync();

      }

      public async Task<int> UpdateBook(UpdateBookDTO bookDto)
      {
            Book? requiredBook = await _dbContext.Books.Where(b => b.BookId == bookDto.BookId).Include(b => b.Authors).FirstOrDefaultAsync();

            if (requiredBook is null)
                  return 0;

            if (!string.IsNullOrEmpty(bookDto.Title) && bookDto.Title != requiredBook.Title)
            {
                  requiredBook.Title = bookDto.Title;
            }

            if (bookDto.Price is not null && bookDto.Price.Value != 0 && bookDto.Price.Value != requiredBook.Price)
            {
                  requiredBook.Price = bookDto.Price.Value;
            }

            if (bookDto.BookCapacity is not null && bookDto.BookCapacity.Value != 0 && bookDto.BookCapacity.Value != requiredBook.Capacity)
            {
                  requiredBook.Capacity = bookDto.BookCapacity.Value;
            }

            if (bookDto.Pages is not null && bookDto.Pages.Value != 0 && bookDto.Pages.Value != requiredBook.Pages)
            {
                  requiredBook.Pages = bookDto.Pages.Value;
            }

            if (!string.IsNullOrEmpty(bookDto.Description) && bookDto.Description != requiredBook.Description)
            {
                  requiredBook.Description = bookDto.Description;
            }


            if (bookDto.Coverage is not null && (BookCover)bookDto.Coverage.Value != requiredBook.Coverage)
            {
                  requiredBook.Coverage = bookDto.Coverage.Value;
            }


            if (bookDto.Authors is not null && bookDto.Authors.Count > 0)
            {
                  List<Author> authors = await DifferentiateEntity<Author>(bookDto.Authors);

                  requiredBook.Authors = authors;

            }

            if (bookDto.Tags is not null && bookDto.Tags.Count > 0)
            {
                  List<Tag> tags = await DifferentiateEntity<Tag>(bookDto.Tags);
                  
                  requiredBook.BookTags = new List<BookTag>();

                  foreach (Tag tag in tags)
                  {
                        requiredBook.BookTags.Add(new BookTag()
                        {
                              Book = requiredBook,
                              Tag = tag
                        });
                  }

            }

            return await _dbContext.SaveChangesAsync();

      }

      private async Task<List<T>> DifferentiateEntity<T>(IEnumerable<string> dtoValues) 
      where T : class, IDifferentiateEntity, new()
      {
            List<T> existingValues = await _dbContext.Set<T>().Where(t => dtoValues.
            Contains(t.Name)).ToListAsync();

            List<T> newValues = dtoValues.Where(t => !existingValues.Any(e => e.Name == t)).
            Select(t => new T { Name = t }).ToList();

            return existingValues.Concat(newValues).ToList();
      }
}


