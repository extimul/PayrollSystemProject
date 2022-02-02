using PayrollSystem.Domain.Interfaces;

namespace PayrollSystem.Domain.Entities;

public class FixedSalary : ISalary
{
    public const double TotalHours = 150;

    public CalculateSalary CalculateSalary { get; }
    public string SalaryTypeName => "Фиксированная";
    public double SalaryAmount { get; }
    public double HoursWorked { get; set; }

    public FixedSalary()
    {
        SalaryAmount = 15000;
    }

    public FixedSalary(double salaryAmount) : this()
    {
        SalaryAmount = salaryAmount;
        CalculateSalary += CalculateEmployeeSalary;
    }

    public FixedSalary(double salaryAmount, double hoursWorked) : this(salaryAmount)
    {
        HoursWorked = hoursWorked;
    }
    
    public double GetEmployeeSalary()
    {
        return CalculateSalary.Invoke();
    }

    private double CalculateEmployeeSalary()
    {
        return (SalaryAmount / TotalHours) * HoursWorked;
    }
}