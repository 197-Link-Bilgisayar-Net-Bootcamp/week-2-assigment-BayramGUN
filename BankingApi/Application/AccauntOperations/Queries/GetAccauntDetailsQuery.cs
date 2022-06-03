using AutoMapper;
using BankingApi.Common;
using BankingApi.DTO;

namespace BankingApi.Application.AccauntOperations.Queries.GetAccauntDetail;

public class GetAccauntDetailQuery
{
    private readonly IAccauntsDbContext _dbContext;
    private readonly IMapper _mapper;
    public int AccauntId { get; set;}
    public GetAccauntDetailQuery(IAccauntsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public AccauntDetailViewModel Handle()
    {
        var accaunt = _dbContext.Accaunts.Where(accaunt => accaunt.Id == AccauntId).SingleOrDefault();
        if(accaunt is null)
            throw new InvalidOperationException("Hesap bulunamadı!");
            
        AccauntDetailViewModel viewModel = _mapper.Map<AccauntDetailViewModel>(accaunt);

        return viewModel;
    }
}
public class AccauntDetailViewModel
{
    public string? Name { get; set; }
    public string? AccauntType { get; set; }
    public string? UserName { get; set; }
    public double? Balance { get; set; }
}