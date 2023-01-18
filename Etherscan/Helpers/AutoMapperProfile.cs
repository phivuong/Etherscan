using System;
using AutoMapper;
using Etherscan.Commands.Token;
using Etherscan.Entities;
using Etherscan.Models.TokenVM;

namespace Etherscan.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TokenCreateUpdateRequest, Token>();
            CreateMap<Token, TokenCreateUpdateVM>();
            CreateMap<Token, TokenDetailVM>();
            CreateMap<TokenCreateUpdateVM, TokenCreateUpdateRequest>();
        }
    }
}

