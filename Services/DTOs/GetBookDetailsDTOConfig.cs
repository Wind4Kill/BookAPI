using System;
using AutoMapper;
using NewBookApi.Domain.Entities;

namespace NewBookApi.Services.DTOs;

public class GetBookDetailsDTOConfig : Profile
{
      public GetBookDetailsDTOConfig()
      {
            CreateMap<Book, GetBookDetailsDTO>().
            ForMember(b => b.IsAvailable,
            m => m.MapFrom(b => b.Capacity > 0 ? true : false));
      }
}
