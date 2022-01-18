using PayrollSystem.App.Common.Interfaces;
using PayrollSystem.App.Common.Persistence;
using PayrollSystem.App.Common.Utils;
using PayrollSystem.Domain.Entities;

namespace PayrollSystem.App.Common.Services;

public class OrganizationBranchManager : IOrganizationBranchManager
{
    public void AddBranch(Branch branch)
    {
        DataContext.Branches.Add(branch);
        Console.WriteLine("Филиал успешно добавлен");
    }

    public void DeleteBranch(Branch branch)
    {
        try
        {
            DataContext.Branches.Remove(branch);
            Console.WriteLine("Филиал успешно удалён");
        }
        catch (Exception)
        {
            Console.WriteLine(ConsoleUtil.INPUT_ERROR);
        }
    }

    public List<Branch> GetOrgBranches() => DataContext.Branches;
}