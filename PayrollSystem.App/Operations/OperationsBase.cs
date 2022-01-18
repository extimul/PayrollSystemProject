using PayrollSystem.App.Common.Interfaces;
using PayrollSystem.App.Common.Services;
using PayrollSystem.App.Common.Utils;
using PayrollSystem.Domain.Entities;
using PayrollSystem.Domain.Interfaces;
using PayrollSystem.Domain.Types;

namespace PayrollSystem.App.Operations;

public abstract class OperationsBase
{
    protected IDivisionManager DivisionManager { get; }
    
    protected IOrganizationBranchManager OrganizationBranchManager { get; }
    
    protected IEmployeeManager EmployeeManager { get; }
    
    protected OperationsBase()
    {
        DivisionManager = new DivisionManager();
        OrganizationBranchManager = new OrganizationBranchManager();
        EmployeeManager = new EmployeeManager();
    }
    
    /// <summary>
    /// Вывод списка филиалов организации
    /// </summary>
    protected void DisplayBranchList()
    {
        var organizationBranches = OrganizationBranchManager.GetOrgBranches();
        ConsoleUtil.DisplayOrgBaseItems(organizationBranches);
    }

    protected void DisplayEmployees(int branchId, int divisionId)
    {
        var employess = EmployeeManager.GetEmployees(new ContextInfo(branchId, divisionId));
        ConsoleUtil.DisplayEmployees(employess);
    }
    
    protected int SelectOrgBranch()
    {
        Console.Clear();
        Console.WriteLine("Выберите филиал");
        DisplayBranchList();
        return ConsoleUtil.IntUserInputHandler();
    }
    
    protected int SelectDivision(int branchId)
    {
        Console.Clear();
        Console.WriteLine("Выберите подразделение");
        var divisions = DivisionManager.GetDivisions(branchId);
        ConsoleUtil.DisplayOrgBaseItems(divisions);
        return ConsoleUtil.IntUserInputHandler();
    }

    protected int SelectEmployee(int branchId, int divisionId)
    {
        Console.Clear();
        DisplayEmployees(branchId, divisionId);
        return ConsoleUtil.IntUserInputHandler();
    }

    protected ISalary BuildEmployeeSalary()
    {
        Console.WriteLine("Выберите тип зарплаты для сотрудника");
        ConsoleUtil.DisplayItems(new[] {"Фиксированная", "Почасовая"});
        int salaryType = ConsoleUtil.IntUserInputHandler();
        ISalary salary;
        switch ((SalaryTypes)salaryType)
        {
            case SalaryTypes.Fixed:
                var amount = Convert.ToDouble(ConsoleUtil.StrUserInputHandler("Введите размер фикс. ежемес. оплаты"));
                salary = new FixedSalary(amount);
                break;
            case SalaryTypes.Hourly:
                var hourlyRate = Convert.ToDouble(ConsoleUtil.StrUserInputHandler("Введите размер часовой оплаты"));
                salary = new HourlySalary(hourlyRate);
                break;
            default:
                salary = new FixedSalary();
                break;
        }

        return salary;
    }

    protected List<Employee> GetAllEmployees()
    {
        var employees = new List<Employee>();
        var branches = OrganizationBranchManager.GetOrgBranches();
        foreach (var division in branches.SelectMany(branch => branch.Divisions))
        {
            employees.AddRange(division.Employees);
        }

        return employees;
    }
}