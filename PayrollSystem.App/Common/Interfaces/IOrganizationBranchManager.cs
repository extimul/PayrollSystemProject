using PayrollSystem.Domain.Entities;

namespace PayrollSystem.App.Common.Interfaces;

public interface IOrganizationBranchManager
{
    void AddBranch(Branch branch);
    void DeleteBranch(Branch branch);
    
    List<Branch> GetOrgBranches();
}