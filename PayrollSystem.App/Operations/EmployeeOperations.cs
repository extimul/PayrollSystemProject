using System.Globalization;
using PayrollSystem.App.Common.Utils;
using PayrollSystem.Domain.Entities;
using PayrollSystem.Domain.Types;

namespace PayrollSystem.App.Operations;

public class EmployeeOperations : OperationsBase
{
    public void AddEmployee()
    {
        int branchId = SelectOrgBranch();
        int divisionId = SelectDivision(branchId);
        var name = ConsoleUtil.StrUserInputHandler("Введите имя сотрудника");
        var lastname = ConsoleUtil.StrUserInputHandler("Введите фамилию сотрудника");
        var salary = BuildEmployeeSalary();
        var newEmployee = salary != null ?
            new Employee(name, lastname, salary) : 
            new Employee(name, lastname);
        
        EmployeeManager.AddEmployee(new ContextInfo(branchId, divisionId), newEmployee);
        Console.WriteLine("Сотрудник успешно добавлен");
    }

    public void RemoveEmployee()
    {
        int branchId = SelectOrgBranch();
        int divisionId = SelectDivision(branchId);
        int employeeId = SelectEmployee(branchId, divisionId);
        EmployeeManager.DeleteEmployee(new ContextInfo(branchId, divisionId, employeeId));
        Console.WriteLine("Сотрудник успешно удалён");
    }

    public void ChangeSalary()
    {
        int branchId = SelectOrgBranch();
        int divisionId = SelectDivision(branchId);
        int employeeId = SelectEmployee(branchId, divisionId);
        var salary = BuildEmployeeSalary();
        EmployeeManager.ChangeSalary(new ContextInfo(branchId, divisionId, employeeId), salary);
        Console.WriteLine("Зарплата сотрудника успешно изменена");
    }

    public void ChangeWorkedTime()
    {
        int branchId = SelectOrgBranch();
        int divisionId = SelectDivision(branchId);
        int employeeId = SelectEmployee(branchId, divisionId);
        var hoursWorked = ConsoleUtil.StrUserInputHandler("Введите количество отработаных часов");
        EmployeeManager.ChangeWorkedHours(new ContextInfo(branchId, divisionId, employeeId), Convert.ToDouble(hoursWorked));
        Console.WriteLine("Отработанные часы сотрнудника успешно изменены");
    }

    public void CalculateSalary()
    {
        int branchId = SelectOrgBranch();
        int divisionId = SelectDivision(branchId);
        int employeeId = SelectEmployee(branchId, divisionId);
        var salary = EmployeeManager.GetEmployeeSalary(new ContextInfo(branchId, divisionId, employeeId));
        Console.WriteLine("Зарпалата сотрудника");
        Console.WriteLine($"Тип зарплаты: {salary.SalaryTypeName}");
        Console.WriteLine($"Итого: {salary.CalculateEmployeeSalary().ToString("C", CultureInfo.CurrentCulture)}");
    }
    public void GetEmployeesByFilteredSalary()
    {
        var employees = GetAllEmployees();

        var filter = Convert.ToDouble(ConsoleUtil.StrUserInputHandler("Введите размер зарплаты X, для вывода списка пользователей у которых з/п > X"));

        foreach (var employee in employees)
        {
            var employeeSalary = employee.Salary.CalculateEmployeeSalary();
            if (employeeSalary >= filter)
            {
                Console.WriteLine(employee.FullName);
            }
        }
    }

    public void GetEmployeesWithFixedSalary()
    {
        var employees = GetAllEmployees();
        foreach (var employee in employees)
        {
            if (employee.Salary.GetType() == typeof(FixedSalary) && employee.Salary.HoursWorked > 150)
            {
                Console.WriteLine($"{employee.FullName} - {employee.Salary.HoursWorked}");
            }
        }
    }

    public void GetTopEmployeesWithHighestSalary()
    {
        var sortedEmployees = GetAllEmployees()
            .OrderByDescending(x => x.Salary.CalculateEmployeeSalary());

        var listSize = Convert.ToInt32(ConsoleUtil.StrUserInputHandler("Введите колличество сотрудников"));

        foreach (var employee in sortedEmployees.Take(listSize))
        {
            Console.WriteLine($"{employee.FullName} - {employee.Salary.CalculateEmployeeSalary()}");
        }
    }
}