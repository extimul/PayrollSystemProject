using PayrollSystem.Domain.Entities;

namespace PayrollSystem.App.Common.Interfaces;

public interface IDivisionManager
{
    public void RemoveDivision(int branchId, int divisionId);

    public void AddDivision(int branchId, Division division);

    public List<Division> GetDivisions(int branchId);
}