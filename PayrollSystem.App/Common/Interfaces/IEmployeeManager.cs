using PayrollSystem.Domain.Entities;
using PayrollSystem.Domain.Interfaces;
using PayrollSystem.Domain.Types;

namespace PayrollSystem.App.Common.Interfaces;

public interface IEmployeeManager
{
    void DeleteEmployee(ContextInfo contextInfo);

    void AddEmployee(ContextInfo contextInfo, Employee employee);

    void ChangeSalary(ContextInfo contextInfo, ISalary salary);

    ISalary GetEmployeeSalary(ContextInfo contextInfo);

    void ChangeWorkedHours(ContextInfo contextInfo, double hoursWorked);
    
    List<Employee> GetEmployees(ContextInfo contextInfo);
}