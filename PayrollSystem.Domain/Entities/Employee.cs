using PayrollSystem.Domain.Interfaces;

namespace PayrollSystem.Domain.Entities;

public class Employee
{
    public string FullName { get; set; }
    
    public ISalary Salary { get; set; }
    
    public Employee(string name, string lastname)
    {
        FullName = $"{name} {lastname}";
        Salary = new FixedSalary(15000);
    }

    public Employee(string name, string lastname, ISalary salary)
        : this(name, lastname)
    {
        Salary = salary;
    }
}