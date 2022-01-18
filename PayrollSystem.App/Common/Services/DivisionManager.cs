using PayrollSystem.App.Common.Interfaces;
using PayrollSystem.App.Common.Persistence;
using PayrollSystem.App.Common.Utils;
using PayrollSystem.Domain.Entities;

namespace PayrollSystem.App.Common.Services;

public class DivisionManager : IDivisionManager
{
    public void RemoveDivision(int branchId, int divisionId)
    {
        try
        {
            var division = DataContext.Branches[branchId].Divisions[divisionId];
            DataContext.Branches[branchId].Divisions.Remove(division);
            Console.WriteLine("Подразделение успешно удалено");
        }
        catch (Exception)
        {
            Console.WriteLine(ConsoleUtil.INPUT_ERROR);
        }
        
    }

    public void AddDivision(int branchId, Division division)
    {
        try
        {
            DataContext.Branches[branchId].Divisions.Add(division);
            Console.WriteLine("Подразделение добавлено успешно");
        }
        catch (Exception)
        {
            Console.WriteLine(ConsoleUtil.INPUT_ERROR);
        }
    }

    public List<Division> GetDivisions(int branchId)
    {
        return DataContext.Branches[branchId].Divisions;
    }
}