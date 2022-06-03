using BankingApi.DTO;
using BankingApi.Common;
using BankingApi.Entities;
using AutoMapper;

namespace BankingApi.Application.AccauntOperations.Queries.GetAccaunts;

public class GetAccauntsQuery
{
    private readonly IAccauntsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAccauntsQuery(IAccauntsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<AccauntsViewModel> Handle()
    {
        var accauntList = _dbContext.Accaunts.OrderBy(ctx => ctx.Id).ToList<Accaunt>();
        List<AccauntsViewModel> viewModel = _mapper.Map<List<AccauntsViewModel>>(accauntList);
        
        return viewModel;
    }
}
public class AccauntsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AccauntType { get; set; }
    public string UserName { get; set; }
    public double Balance { get; set; }
}
