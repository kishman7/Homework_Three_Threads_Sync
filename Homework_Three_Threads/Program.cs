using System;
using System.Threading;

namespace Homework_Three_Threads
{
    class Program
    {
        static object locker = new object();
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number for factorial, syma, fibonachi: ");
            int number = int.Parse(Console.ReadLine());
            Thread[] threads = new Thread[3];
            for (int i = 0; i < threads.Length; i++)
            {
                if (i == 0)
                {
                    threads[i] = new Thread(Factorial);
                    threads[i].Start(number);
                    threads[i].Join();
                }
                else if (i == 1)
                {
                    threads[i] = new Thread(Syma);
                    threads[i].Start(number);
                    threads[i].Join();
                }
                else if (i == 2)
                {
                    threads[i] = new Thread(Fibonachi);
                    threads[i].Start(number);
                    threads[i].Join();
                }

            }
            ShowInfo(number);
            //for (int i = 0; i < threads.Length; i++) //вивід на екран
            //{
            //    threads[i] = new Thread(ShowInfo);
            //    threads[i].Start(number);
            //    threads[i].Join();
            //}

            
        }

        private static void Factorial(object obj) //метод для визначення факторіалу
        {
            int result = 1;
            for (int i = 1; i < (int)obj + 1; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Result factorial number {(int)obj}: {result}");
        }

        private static void Syma(object obj) //метод для визначення суми
        {
            int result = 0;
            for (int i = 1; i < (int)obj + 1; i++)
            {
                result += i;
            }
            Console.WriteLine($"Result syma number {(int)obj}: {result}");
        }

        private static void Fibonachi(object obj) //метод для визначення фібоначі
        {
            int result = 1; int next = 1;
            for (int i = 0; i < (int)obj; i++)
            {
                int temp = next;
                next = result + next;
                result = temp;
            }
            Console.WriteLine($"Result fibonachi number {(int)obj}: {result}");
        }

        private static void ShowInfo(object obj) //метод виводу на екран
        {
            Console.WriteLine("i\t\tSyma\t\tFibonachi\tFactorial");
            int factorial = 1;
            int syma = 0;
            int fibonachi = 1; int next = 1;

            lock (locker)
            {
                for (int i = 1; i < (int)obj + 1; i++)
                {
                    factorial *= i;
                    syma += i;
                    int temp = next;
                    next = fibonachi + next;
                    fibonachi = temp;
                    Console.WriteLine($"{i}.\t\t{syma}\t\t{fibonachi}\t\t{factorial}"); 
                    Thread.Sleep(100);
                }
            }

        }

    }
}
