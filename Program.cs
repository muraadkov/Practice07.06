using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice07._06
{
    class Program
    {
        static object locker = new object();
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[10];
            for (int i = 1; i < threads.Length; i++)
            {
                threads[i] = new Thread(CashSynchro);
                threads[i].Name = string.Format(": #{0}", i);
                threads[i].Start();
            }
            Console.ReadLine();
            for (int i = 1; i < threads.Length; i++)
            {
                threads[i] = new Thread(Cash);
                threads[i].Name = string.Format(": #{0}", i);
                threads[i].Start();
            }
            Console.ReadLine();
        }
        public static void CashSynchro()
        {

            lock (locker)
            {
                
                User user = new User()
                {
                    Amount = 1000,
                    Name = "Муратжан"
                };
                Console.WriteLine($"Приветствуем вас, {user.Name}.\nНа вашем счету: {user.Amount}\nБанк{Thread.CurrentThread.Name} начал работу");
                for (int i = 1; i <= 10; i++)
                {

                    var rand = new Random().Next(0, 2);
                    if (rand == 0)
                    {
                        Thread.Sleep(5 * new Random().Next(100));
                        user.Amount += 100;
                        Console.WriteLine($"\nНа вашем счету: {user.Amount}, начислилось 100");
                    }
                    else if (rand == 1)
                    {
                        Thread.Sleep(5 * new Random().Next(100));
                        user.Amount -= 100;
                        Console.WriteLine($"\nНа вашем счету: {user.Amount}, снялось 100");
                    }
                }
            }

        }

        public static void Cash() {
            User user = new User()
            {
                Amount = 1000,
                Name = "Муратжан"
            };
            Console.WriteLine($"Приветствуем вас, {user.Name}.\nНа вашем счету: {user.Amount}\nБанк{Thread.CurrentThread.Name} начал работу");

            for (int i = 0; i < 10; i++)
            {
                var rand = new Random().Next(0, 2);
                if(rand == 0)
                {
                    Thread.Sleep(5 * new Random().Next(100));
                    user.Amount += 100;
                    Console.WriteLine($"\nНа вашем счету: {user.Amount}, начислилось 100");
                }
                else if(rand == 1)
                {
                    Thread.Sleep(5 * new Random().Next(100));
                    user.Amount -= 100;
                    Console.WriteLine($"\nНа вашем счету: {user.Amount}, снялось 100");
                }
            }

    }
    }
}
