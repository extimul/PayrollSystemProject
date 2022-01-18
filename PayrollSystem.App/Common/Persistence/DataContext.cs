using PayrollSystem.Domain.Entities;

namespace PayrollSystem.App.Common.Persistence;

public static class DataContext
{
    public static List<Branch> Branches = new();

    public static void Seed()
    {
        Branches.AddRange(new List<Branch>()
        {
            new()
            {
                Name = "Филиал 1",
                Divisions = new List<Division>()
                {
                    new()
                    {
                        Name = "Подразделение 1",
                        Employees = new List<Employee>()
                        {
                            new("Ivan", "Ivanov", new FixedSalary(25000, 150)),
                            new("Petr", "Petrov", new HourlySalary(23213, 123)),
                            new("Anastasiya", "Vasileva", new FixedSalary(42213, 160)),
                        }
                    },
                    new()
                    {
                        Name = "Подразделение 2",
                        Employees = new List<Employee>()
                        {
                            new("Dmitriy", "Ivanov", new HourlySalary(120, 200)),
                            new("Artur", "Alexandrov", new FixedSalary(42000, 174)),
                            new("Angela", "Petrova", new HourlySalary(130, 92)),
                        }
                    }
                }
            },
            new()
            {
                Name = "Филиал 2",
                Divisions = new List<Division>()
                {
                    new()
                    {
                        Name = "Подразделение 3",
                        Employees = new List<Employee>()
                        {
                            new("Ivan", "Alexandrov", new FixedSalary(25000, 11)),
                            new("Alexandr", "Petrov", new HourlySalary(23213, 234)),
                            new("Vasiliy", "Petrov", new FixedSalary(42213, 44)),
                        }
                    },
                    new()
                    {
                        Name = "Подразделение 4",
                        Employees = new List<Employee>()
                        {
                            new("Dmitriy", "Ivanov", new HourlySalary(420, 99)),
                            new("Artur", "Fedorov", new FixedSalary(32000, 169)),
                            new("Alisa", "Ivanova", new HourlySalary(1230, 181)),
                        }
                    }
                }
            }
        });
        Console.WriteLine("Тестовые данные успешно загружены");
    }
}