using System;
using AutoMapper;
using NewBookApi.Domain.Entities;

namespace NewBookApi.Services.DTOs;

public class BookTagToStringConfig:Profile
{
      public BookTagToStringConfig()
      {
            CreateMap<BookTag, string>().ConvertUsing(bt => bt.Tag.Name);
      }
}
