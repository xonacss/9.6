using System;

public class MyException : Exception
{
    public MyException(string message) : base(message) { }
}
class Program
{
    static void Main()
    {
        Exception[] exceptions =
        {
            new DivideByZeroException("Деления на 0"),
            new ArgumentNullException("Аргумент, передаваемый в метод — null."),
            new IndexOutOfRangeException ("Индекс находится за пределами границ массива или коллекции."),
            new InvalidOperationException("Недопустимая операция!"),
            new MyException ("Кастом")
        };
        foreach (var e in exceptions)
        {
            try
            {
                throw e;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine("Ошибка: {0} (На ноль делить нельзя!)", e.Message);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine("Ошибка: {0} (Передан null вместо значения!)", e.Message);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine("Ошибка: {0} (Проверьте границы массива!)", e.Message);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine("Ошибка: {0} (Операция не поддерживается!)", e.Message);
            }
            catch (MyException)
            {
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine("Ошибка: {0} (Кастомное исключение!)", e.Message);
            }
        }
        Console.WriteLine("Все исключения обработаны");
        Console.ReadKey();
    }
}
