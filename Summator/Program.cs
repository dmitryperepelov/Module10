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

                var summator = new Summator(new Logger());

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
        private ILogger logger;

        public Summator(ILogger logger)
        {
            this.logger = logger;
        }

        public int Sum(int a, int b)
        {
            try
            {
                logger.EventLog($"Сложение чисел {a} и {b}");
                return checked(a + b);
            }
            catch(Exception exception)
            {
                logger.ErrorLog(exception.Message);
                return 0;
            }
        }
    }

    public class Logger : ILogger
    {
        public void ErrorLog(string message)
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
        }

        public void EventLog(string message)
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
        }
    }
}
