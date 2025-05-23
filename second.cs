using System;

public class MyException : Exception
{
    public MyException(string message) : base(message) { }
}

class Program
{
    public delegate void SortHandler(string[] names, int sortType);
    public static event SortHandler OnSortRequested;

    static void Main()
    {
        OnSortRequested += SortNames;

        string[] names = { "Иванов", "Петров", "Сидоров", "Алексеев", "Зайцев" };

        Console.WriteLine("Исходный список фамилий:");
        PrintArray(names);

        while (true)
        {
            Console.WriteLine("\nВведите 1 для сортировки А-Я или 2 для сортировки Я-А :");

            try
            {
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int sortType) || (sortType != 1 && sortType != 2))
                {
                    throw new MyException("Ошибка: можно вводить только 1 или 2!");
                }

                OnSortRequested?.Invoke(names, sortType);

                Console.WriteLine("\nОтсортированный список:");
                PrintArray(names);
            }
            catch (MyException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine("Для продолжения введите новую команду...");
            }
        }
    }

    private static void SortNames(string[] names, int sortType)
    {
        if (sortType == 1)
        {
            Array.Sort(names);
        }
        else
        {
            Array.Sort(names, (x, y) => y.CompareTo(x)); 
        }
    }

    private static void PrintArray(string[] array)
    {
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }
}
