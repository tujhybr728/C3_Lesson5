using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace C3_Lesson5
{
    class Program
    {
        private static bool downwork = true;
        private static bool downwork2 = true;
        private static int sbs1 = 0;
        private static int sbs2 = 1;
        private static int downsleep;
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите число для вычисления его суммы и факториала");
            int parameter = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Укажите время задержки");
            downsleep = Int32.Parse(Console.ReadLine());
            var treads = new List<Thread>();       
            var thread = new Thread(() => Summ(parameter));
            var thread2 = new Thread(() => Integral(parameter));
            
            thread.IsBackground = true;
            thread.Start();
            thread2.IsBackground = true;
            thread2.Start();
            while (thread.IsAlive || thread2.IsAlive)
            {
                Console.ReadLine();
                Console.WriteLine("Один из процессов не завершён завершить его Y/N?");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Y:
                        {
                            downwork = false;
                            downwork2 = false;
                            thread.Abort();
                            thread2.Abort();
                            break;
                        }
                    case ConsoleKey.N:
                        {
                            Console.WriteLine("Процессы продолжат работу");
                            break;
                        }
                    default: break;
                }
            }
            Console.WriteLine($"Факториал числа: { sbs1}");
            Console.WriteLine($"Результат сложения всех чисел: { sbs2}");
            Console.WriteLine("Процесс завершён досвидания");
                Console.ReadLine();
        }
       
        
        private static void Summ(int table)
        {
            for (var i = 0; (downwork) & (i < table); i++)
            {
                Thread.Sleep(downsleep);
                sbs1 = sbs1 + i;
            }
        }

        private static void Integral(int table)
        {
            int sbs = 1;
            for (var i = 1; (downwork2) & (i < table+1); i++)
            {
                Thread.Sleep(downsleep);
                sbs2 = sbs2 * i;
            }
        }
    }
}
