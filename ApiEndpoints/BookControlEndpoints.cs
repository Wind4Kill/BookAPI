using System;
using Microsoft.AspNetCore.Mvc;
using NewBookApi.Services;
using NewBookApi.Services.DTOs;

namespace NewBookApi.ApiEndpoints;

public static class BookControlEndpoints
{
      public static void AddBookControlEndpoints(this WebApplication app)
      {
            RouteGroupBuilder booksBuilder = app.MapGroup("Books").WithTags("Books");

            booksBuilder.MapPost("All", async (BooksControlService service, [FromBody] SortFilterOptions? options) =>
            {
                  if (options is null)
                  {
                        options = new SortFilterOptions();
                  }
                  List<GetBookDTO> books = await service.GetBooks(options);

                  return Results.Ok<List<GetBookDTO>>(books);
            }).Produces<List<CreateBookDTO>>();

            booksBuilder.MapGet("{id:int}", async (int id, BooksControlService service) =>
            {
                  GetBookDetailsDTO? requiredBook = await service.GetBookById(id);

                  return requiredBook is not null ?
                  Results.Ok(requiredBook) :
                  Results.Problem(detail: "Such book hasn't been found.", statusCode: 404);
            }).WithName("GetBook")
            .Produces<CreateBookDTO>()
            .ProducesProblem(statusCode: 404);

            booksBuilder.MapPost("", async (CreateBookDTO book, BooksControlService service) =>
            {
                  int affectedRows = await service.AddBook(book);

                  return affectedRows is -1 or 0 ? Results.Problem("Book hasn't been added.", statusCode: 400) :
                  Results.Created();
            }).WithParameterValidation().Produces(statusCode: 201).ProducesProblem(statusCode: 400);

            booksBuilder.MapDelete("{id:int}", async (int id, BooksControlService service) =>
            {
                  int affectedRows = await service.RemoveBook(id);

                  return affectedRows is not -1 or 0 ? Results.NoContent() :
                  Results.Problem("Book couldn't be deleted.", statusCode: 400);
            }).Produces(statusCode: 204).ProducesProblem(statusCode: 400);

            booksBuilder.MapPut("", async (UpdateBookDTO bookDTO, BooksControlService sevice) =>
            {
                  int affectedRows = await sevice.UpdateBook(bookDTO);

                  return affectedRows is -1 or 0 ? Results.Problem(detail: "Book can't be updated.", statusCode: 400) :
                  Results.NoContent();
            }).WithParameterValidation().Produces(statusCode: 204).ProducesProblem(statusCode: 400);


      }
}