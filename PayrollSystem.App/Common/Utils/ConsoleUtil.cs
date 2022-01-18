using PayrollSystem.Domain.Entities;

namespace PayrollSystem.App.Common.Utils;

public class ConsoleUtil
{
    public static string INPUT_ERROR = "Проверьте правильность ввода данных";

    public static string StrUserInputHandler(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        return Console.ReadLine() ?? default;
    }
    
    public static int IntUserInputHandler()
    {
        var input = Convert.ToInt32(Console.ReadLine());
        return input - 1;
    }

    public static void DisplayItems(string[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            Console.WriteLine($"{i+1}.{items[i]}");
        }
    }
    
    public static void DisplayOrgBaseItems<T>(IEnumerable<T> items) where T : BaseModel
    {
        var sortedList = items.OrderBy(x => x.Name).ToList();
        for (int i = 0; i < sortedList.Count; i++)
        {
            Console.WriteLine($"{i+1}.{sortedList[i].Name}");
        }
    }

    public static void DisplayEmployees(List<Employee> employees)
    {
        Console.Clear();
        Console.WriteLine("Сотрудники:");
        for (int i = 0; i < employees.Count; i++)
        {
            Console.WriteLine($"{i+1}.{employees[i].FullName}");
        }
    }
}