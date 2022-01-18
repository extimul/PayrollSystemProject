using PayrollSystem.Domain.Interfaces;

namespace PayrollSystem.Domain.Entities;

public class HourlySalary : ISalary
{
    public string SalaryTypeName => "Почасовая оплата";

    public double HourlyRate { get; }

    public double HoursWorked { get; set; }

    public HourlySalary(double hourlyRate)
    {
        HourlyRate = hourlyRate;
    }
    
    public HourlySalary(double hourlyRate, double hoursWorked) : this(hourlyRate)
    {
        HoursWorked = hoursWorked;
    }

    public double CalculateEmployeeSalary()
    {
        return HourlyRate * HoursWorked;
    }
}