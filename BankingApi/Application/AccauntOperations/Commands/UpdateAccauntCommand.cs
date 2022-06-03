using BankingApi.DTO;

namespace BankingApi.Application.AccauntOperations.Commands.UpdateAccaunt;

public class UpdateAccauntCommand
{
    private readonly IAccauntsDbContext _context;
    public int AccauntId { get; set; }
    public UpdateAccauntModel Model { get; set; }

    public UpdateAccauntCommand(IAccauntsDbContext context)
    {
        _context = context;
    }
    public void Handle()
    {
        var accaunt = _context.Accaunts.SingleOrDefault(ctx => ctx.Id == AccauntId);
        if(accaunt is null)
            throw new InvalidOperationException("Güncellenecek accaunt bulunamadı!");
            
        accaunt.Name = Model.Name != default ? Model.Name : accaunt.Name;
        accaunt.Balance = Model.Balance != default ? Model.Balance : accaunt.Balance;

        _context.SaveChanges();        
    }
}

public class UpdateAccauntModel
{
    public string Name { get; set; }
    public double Balance { get; set; }
}