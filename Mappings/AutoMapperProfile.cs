﻿using AutoMapper;
using identity_jwt.Models;
using identity_jwt.Models.DTOs;

namespace identity_jwt.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
        }
    }
}