using PayrollSystem.App.Common.Handlers;
using PayrollSystem.App.Common.Utils;

namespace PayrollSystem.App;

class Program
{
    private static bool _isRunning = true;

    private static Dictionary<int, string> MenuItems => new()
    {
        {1, "Добавить филиал организации"},
        {2, "Удалить филиал организации"},
        {3, "Добавить подразделение организации"},
        {4, "Удалить подразделение организации"},
        {5, "Добавить сотрудника"},
        {6, "Удалить сотрудника"},
        {7, "Сменить тип оплаты и размер оплаты"},
        {8, "Изменить отработанное время для сотрудника"},
        {9, "Расчитать зарплату за месяц"},
        {10, "Список филиалов"},
        {11, "Список подразделений"},
        {12, "Список филиалов с колличеством сотрудников"},
        {13, "Расчетный лист(с з/п) для филиала и подразделения"},
        {14, "Список филиалов с укзанием кол-ва сотрудников и группировкой по подразделениями"},
        {15, "Список филиалов с указанием средней зарплаты сотрудников"},
        {16, "Список сотрудников, зарплаты которых больше заданного фильтра"},
        {17, "Список сотрудников с фиксированной з/п, которые отработали все требуемые часы"},
        {18, "Список сотрудников с наибольшим размером з/п в текущем месяце"},
        {19, "Тестовые данные"},
        {20, "Выход"},
    };

    private static void Main(string[] args)
    {
        var handler = new OperationHandler();
        while (_isRunning)
        {
            DisplayMainMenu();
            var userInput = HandleUserInput();
            handler.InvokeOperation(userInput);
            Console.ReadKey();
        }
    }

    private static int HandleUserInput()
    {
        Console.WriteLine("Выберите действие:");
        return Convert.ToInt16(Console.ReadLine());
    }

    private static void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Система расчета оплаты труда сотрудников");
        foreach (var (key, value) in MenuItems)
        {
            Console.WriteLine($"{key}.{value}");
        }
    }
}

