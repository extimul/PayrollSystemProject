using System.Diagnostics;
using PayrollSystem.App.Common.Persistence;
using PayrollSystem.App.Operations;

namespace PayrollSystem.App.Common.Handlers;

public class OperationHandler
{
    private readonly Dictionary<int, Delegate> _operationStore;

    public OperationHandler()
    {
        var orgOperations = new OrganizationUnitOperations();
        var employeeOperation = new EmployeeOperations();
        
        _operationStore = new Dictionary<int, Delegate>()
        {
            { 1, new Action(orgOperations.AddOrganizationBranch)},
            { 2, new Action(orgOperations.RemoveOrganizationBranch)},
            { 3, new Action(orgOperations.AddDivision)},
            { 4, new Action(orgOperations.RemoveDivision)},
            { 5, new Action(employeeOperation.AddEmployee)},
            { 6, new Action(employeeOperation.RemoveEmployee)},
            { 7, new Action(employeeOperation.ChangeSalary)},
            { 8, new Action(employeeOperation.ChangeWorkedTime)},
            { 9, new Action(employeeOperation.CalculateSalary)},
            { 10, new Action(orgOperations.DisplayOrgBranchList)},
            { 11, new Action(orgOperations.DisplayDivisionList)},
            { 12, new Action(orgOperations.DisplayBranchListWithEmployeeNum)},
            { 13, new Action(orgOperations.DisplayWorksheet)},
            { 14, new Action(orgOperations.DisplayBranchListWithDivisions)},
            { 15, new Action(orgOperations.DisplayBranchesWithAvgSalary)},
            { 16, new Action(employeeOperation.GetEmployeesByFilteredSalary)},
            { 17, new Action(employeeOperation.GetEmployeesWithFixedSalary)},
            { 18, new Action(employeeOperation.GetTopEmployeesWithHighestSalary)},
            { 19, new Action(DataContext.Seed)},
            { 20, new Action(Process.GetCurrentProcess().Kill)}
        };
    }
    
    public void InvokeOperation(int operationId)
    {
        _operationStore[operationId].DynamicInvoke();
    }
}