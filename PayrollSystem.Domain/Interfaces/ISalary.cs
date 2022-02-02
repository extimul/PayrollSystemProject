namespace PayrollSystem.Domain.Interfaces;

public delegate double CalculateSalary();

public interface ISalary
{
    public CalculateSalary? CalculateSalary { get; }
    public string SalaryTypeName { get; }
    public double HoursWorked { get; set; }
    public double GetEmployeeSalary();
}