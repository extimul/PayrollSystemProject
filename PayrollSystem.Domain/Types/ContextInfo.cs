namespace PayrollSystem.Domain.Types;

public struct ContextInfo
{
    public readonly int BranchId;

    public readonly int DivisionId;

    public readonly int EmployeeId;

    public ContextInfo(int branchId) : this()
    {
        BranchId = branchId;
    }

    public ContextInfo(int branchId, int divisionId) : this(branchId)
    {
        DivisionId = divisionId;
    }

    public ContextInfo(int branchId, int divisionId, int employeeId) : this(branchId, divisionId)
    {
        EmployeeId = employeeId;
    }
}