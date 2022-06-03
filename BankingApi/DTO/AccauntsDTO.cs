using Microsoft.EntityFrameworkCore;
using BankingApi.Entities;

namespace BankingApi.DTO;

public class AccauntDbContext : DbContext, IAccauntsDbContext
{
    public AccauntDbContext(DbContextOptions<AccauntDbContext> options) : base(options) 
    { }
    public DbSet<Accaunt> Accaunts { get; set; }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}

