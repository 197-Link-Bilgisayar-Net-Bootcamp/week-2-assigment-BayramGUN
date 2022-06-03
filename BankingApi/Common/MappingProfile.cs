using AutoMapper;
using BankingApi.Application.AccauntOperations.Commands.CreateAccaunt;
using BankingApi.Application.AccauntOperations.Queries.GetAccauntDetail;
using BankingApi.Application.AccauntOperations.Queries.GetAccaunts;
using BankingApi.Entities;

namespace BankingApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateAccauntModel, Accaunt>();
        CreateMap<Accaunt, AccauntDetailViewModel>();
        CreateMap<Accaunt, AccauntsViewModel>();
    }
}