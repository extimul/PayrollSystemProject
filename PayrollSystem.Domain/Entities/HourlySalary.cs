using PayrollSystem.Domain.Interfaces;

namespace PayrollSystem.Domain.Entities;

public class HourlySalary : ISalary
{
    public CalculateSalary CalculateSalary { get; }
    public string SalaryTypeName => "Почасовая оплата";

    public double HourlyRate { get; }

    public double HoursWorked { get; set; }
    

    public HourlySalary(double hourlyRate)
    {
        HourlyRate = hourlyRate;
        CalculateSalary += CalculateEmployeeSalary;
    }
    
    public HourlySalary(double hourlyRate, double hoursWorked) : this(hourlyRate)
    {
        HoursWorked = hoursWorked;
    }
    
    public double GetEmployeeSalary()
    {
        return CalculateSalary.Invoke();
    }

    private double CalculateEmployeeSalary()
    {
        return HourlyRate * HoursWorked;
    }
}