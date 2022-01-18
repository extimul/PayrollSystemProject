namespace PayrollSystem.Domain.Interfaces;

public interface ISalary
{
    public string SalaryTypeName { get; }
    public double HoursWorked { get; set; }
    double CalculateEmployeeSalary();
}