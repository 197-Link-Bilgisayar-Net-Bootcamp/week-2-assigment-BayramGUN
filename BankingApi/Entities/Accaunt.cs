using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApi.Entities;

public class Accaunt
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public double Balance { get; set; }
    public string AccauntType { get; set; }
    public string UserName { get; set; }
}