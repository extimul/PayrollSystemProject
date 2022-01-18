namespace PayrollSystem.Domain.Entities;

public class Branch : BaseModel
{
    public List<Division> Divisions { get; set; } = new();
}