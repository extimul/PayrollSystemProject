namespace PayrollSystem.Domain.Entities;

public class Division : Branch
{
    public List<Employee> Employees { get; set; } = new();
}