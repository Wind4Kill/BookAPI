using System;
using Microsoft.AspNetCore.Http.HttpResults;
using NewBookApi.Services;
using NewBookApi.Services.DTOs;
using NewBookApi.Services.ServiceInterfaces;

namespace NewBookApi.ApiEndpoints;

public static class AuthorControlEndpoints
{
      public static void AddAuthorControlEndpoints(this WebApplication app)
      {
            var builder = app.MapGroup("Authors").WithTags("Authors");

            builder.MapGet("All", async (IAuthorControlService service) =>
            {
                  List<GetAuthorDTO>? authorDtos = await service.GetAuthors();

                  return authorDtos is not null ? Results.Ok<List<GetAuthorDTO>>(authorDtos) :
                  Results.Problem("There are no results founded.", statusCode: 404);
            }).Produces(statusCode: 200).ProducesProblem(statusCode: 404);

            builder.MapGet("{id:int}", async (int id, IAuthorControlService service) =>
            {
                  GetAuthorDetailsDTO? authorDto = await service.GetAuthorById(id);

                  return authorDto is not null ? Results.Ok<GetAuthorDetailsDTO>(authorDto) 
                  : Results.Problem("Data hasn't been found.", statusCode: 404);
            }).Produces(statusCode:200).ProducesProblem(statusCode:404);
      }
}
