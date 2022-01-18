using PayrollSystem.App.Common.Persistence;
using PayrollSystem.App.Common.Utils;
using PayrollSystem.Domain.Entities;
using PayrollSystem.Domain.Types;

namespace PayrollSystem.App.Operations;

public class OrganizationUnitOperations : OperationsBase
{
    /// <summary>
    /// Добавление филиала
    /// </summary>
    public void AddOrganizationBranch()
    {
        Console.Clear();
        Console.WriteLine("Введите название филиала");
        var orgName = Console.ReadLine();
        OrganizationBranchManager.AddBranch(new Branch()
        {
            Name = orgName ?? "NoName branch",
        });
    }

    /// <summary>
    /// Удаление филиала
    /// </summary>
    public void RemoveOrganizationBranch()
    {
        int branchId = SelectOrgBranch();
        OrganizationBranchManager.DeleteBranch(DataContext.Branches[branchId - 1]);
    }

    /// <summary>
    /// Добавления подразделения
    /// </summary>
    public void AddDivision()
    {
        var branchId = SelectOrgBranch();
        Console.WriteLine("Введите название подразделения");
        var divisionName = Console.ReadLine() ?? "NoName division";
        DivisionManager.AddDivision(branchId, new Division() { Name = divisionName});
    }

    /// <summary>
    /// Удаление подразделения
    /// </summary>
    public void RemoveDivision()
    {
        int branchId = SelectOrgBranch();
        int divisionId = SelectDivision(branchId);
        DivisionManager.RemoveDivision(branchId, divisionId);
    }

    /// <summary>
    /// Вывод списка филиалов организации
    /// </summary>
    public void DisplayOrgBranchList()
    {
        DisplayBranchList();
    }
    
    /// <summary>
    /// Вывод списка подразделений филиала
    /// </summary>
    public void DisplayDivisionList()
    {
        Console.Clear();
        var branchId = SelectOrgBranch();
        var divisions = DivisionManager.GetDivisions(branchId);
        ConsoleUtil.DisplayOrgBaseItems(divisions);
    }

    /// <summary>
    /// Вывод списка филиалов с количеством персонала
    /// </summary>
    public void DisplayBranchListWithEmployeeNum()
    {
        var branches = OrganizationBranchManager.GetOrgBranches().OrderBy(x => x.Name).ToList();
        foreach (var branch in branches)
        {
            int employeeCount = branch.Divisions.Sum(division => division.Employees.Count);
            Console.WriteLine($"{branch.Name} - Кол-во сотрудников: {employeeCount}");
        }
    }

    /// <summary>
    /// Вывод списка филиалов с поразделениями в которых указано кол-во сотрудников
    /// </summary>
    public void DisplayBranchListWithDivisions()
    {
        Console.Clear();
        var branches = OrganizationBranchManager.GetOrgBranches()
            .OrderBy(x => x.Name)
            .ToList();
        for (int brIndex = 0; brIndex < branches.Count; brIndex++)
        {
            Console.WriteLine($"[{brIndex + 1}] {branches[brIndex].Name}:");
            for (int divIndex = 0; divIndex < branches[brIndex].Divisions.Count; divIndex++)
            {
                int employeeCount = branches[brIndex].Divisions[divIndex].Employees.Count;
                Console.WriteLine($"\t({divIndex + 1}) {branches[brIndex].Divisions[divIndex].Name}: {employeeCount} чел");
            }
        }
    }

    /// <summary>
    /// Вывод расчетного листа
    /// </summary>
    public void DisplayWorksheet()
    {
        int branchId = SelectOrgBranch();
        int divisionId = SelectDivision(branchId);
        var employees = EmployeeManager
            .GetEmployees(new ContextInfo(branchId, divisionId))
            .OrderBy(x => x.FullName)
            .ToList();
        for (int i = 0; i < employees.Count; i++)
        {
            Console.WriteLine($"{i+1}.{employees[i].FullName} - З/п: {employees[i].Salary.CalculateEmployeeSalary():F3}");
        }
    }

    /// <summary>
    /// Вывод списка филиалов с средней зарплатой
    /// </summary>
    public void DisplayBranchesWithAvgSalary()
    {
        var branches = OrganizationBranchManager.GetOrgBranches();
        for (int i = 0; i < branches.Count; i++)
        {
            double avgSalary = 0;
            foreach (var div in branches[i].Divisions)
            {
                avgSalary = div.Employees.Average(x => x.Salary.CalculateEmployeeSalary());
            }
            Console.WriteLine($"{i+1}.{branches[i].Name} - Среднее з/п: {avgSalary:F3}");
        }
    }
}