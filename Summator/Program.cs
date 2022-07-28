using System;

namespace Summator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите первое число: ");
                var int1 = int.Parse(Console.ReadLine());
                Console.Write("Введите второе число: ");
                var int2 = int.Parse(Console.ReadLine());

                var summator = new Summator();

                Console.WriteLine($"Сумма: {summator.Sum(int1, int2)}");
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadKey();
        }
    }

    public class Summator : ISum
    {
        public int Sum(int a, int b)
        {
            return checked(a + b);
        }
    }
}
