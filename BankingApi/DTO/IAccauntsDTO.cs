using Microsoft.EntityFrameworkCore;
using BankingApi.Entities;

namespace BankingApi.DTO;

public interface IAccauntsDbContext
{    
     DbSet<Accaunt> Accaunts { get; set; }
     int SaveChanges();
}
