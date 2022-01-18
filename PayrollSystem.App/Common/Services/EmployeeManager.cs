using PayrollSystem.App.Common.Interfaces;
using PayrollSystem.App.Common.Persistence;
using PayrollSystem.App.Common.Utils;
using PayrollSystem.Domain.Entities;
using PayrollSystem.Domain.Interfaces;
using PayrollSystem.Domain.Types;

namespace PayrollSystem.App.Common.Services;

public class EmployeeManager : IEmployeeManager
{
    public void AddEmployee(ContextInfo contextInfo, Employee employee)
    {
        try
        {
            DataContext.Branches[contextInfo.BranchId].Divisions[contextInfo.DivisionId].Employees.Add(employee);
        }
        catch (Exception)
        {
            Console.WriteLine(ConsoleUtil.INPUT_ERROR);
        }
    }

    public void DeleteEmployee(ContextInfo contextInfo)
    {
        try
        {
            var employee = DataContext
                .Branches[contextInfo.BranchId]
                .Divisions[contextInfo.DivisionId]
                .Employees[contextInfo.EmployeeId];
            
            DataContext.Branches[contextInfo.BranchId]
                .Divisions[contextInfo.DivisionId]
                .Employees.Remove(employee);
        }
        catch (Exception)
        {
            Console.WriteLine("Такого сотрудника не существует");
            Console.WriteLine(ConsoleUtil.INPUT_ERROR);
        }
    }
    
    public void ChangeSalary(ContextInfo contextInfo, ISalary salary)
    {
        DataContext.Branches[contextInfo.BranchId]
            .Divisions[contextInfo.DivisionId]
            .Employees[contextInfo.EmployeeId]
            .Salary = salary;
    }

    public ISalary GetEmployeeSalary(ContextInfo contextInfo)
    {
        return DataContext
            .Branches[contextInfo.BranchId]
            .Divisions[contextInfo.DivisionId]
            .Employees[contextInfo.EmployeeId]
            .Salary;
    }

    public void ChangeWorkedHours(ContextInfo contextInfo, double hoursWorked)
    {
        DataContext.Branches[contextInfo.BranchId]
            .Divisions[contextInfo.DivisionId]
            .Employees[contextInfo.EmployeeId]
            .Salary.HoursWorked = hoursWorked;
    }

    public List<Employee> GetEmployees(ContextInfo contextInfo)
    {
        return DataContext.Branches[contextInfo.BranchId]
            .Divisions[contextInfo.DivisionId].Employees;
    }
}