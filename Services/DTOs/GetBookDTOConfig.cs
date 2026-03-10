using System;
using AutoMapper;
using NewBookApi.Domain.Entities;

namespace NewBookApi.Services.DTOs;

public class GetBookDTOConfig:Profile
{
      public GetBookDTOConfig()
      {
            CreateMap<Book, GetBookDTO>()
            .ForMember(b => b.Rating,
            m => m.MapFrom(b => b.Reviews!.Average(r => (decimal?)r.Stars)));
      }
}
