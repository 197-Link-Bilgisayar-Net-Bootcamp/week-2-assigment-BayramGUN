using BankingApi.DTO;

namespace BankingApi.Application.AccauntOperations.Commands.DeleteAccaunt;

public class DeleteAccauntCommand
{
    private readonly IAccauntsDbContext _dbContext;
    public int AccauntId { get; set; }
    public DeleteAccauntCommand(IAccauntsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Handle()
    {
        var accaunt = _dbContext.Accaunts.SingleOrDefault(ctx => ctx.Id == AccauntId);
        if(accaunt is null)
            throw new InvalidOperationException("Silinecek hesap bulunamadı!");

        _dbContext.Accaunts.Remove(accaunt);
        _dbContext.SaveChanges();
    }
}
