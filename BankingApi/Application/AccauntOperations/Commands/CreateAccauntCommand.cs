using AutoMapper;
using BankingApi.DTO;
using BankingApi.Entities;

namespace BankingApi.Application.AccauntOperations.Commands.CreateAccaunt;
public class CreateAccauntCommand
{
    public CreateAccauntModel Model { get; set; }
    private readonly IAccauntsDbContext _dbContext;
    private readonly IMapper _mapper;
    public CreateAccauntCommand(IAccauntsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public void Handle()
    {
        var accaunt = _dbContext.Accaunts.SingleOrDefault(ctx => ctx.AccauntType == Model.AccauntType);
        if(accaunt is not null)
            throw new InvalidOperationException("Hesap zaten mevcut!");
        accaunt = _mapper.Map<Accaunt>(Model);

        _dbContext.Accaunts.Add(accaunt);
        _dbContext.SaveChanges();
    }


}

public class CreateAccauntModel
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string AccauntType { get; set; }
}