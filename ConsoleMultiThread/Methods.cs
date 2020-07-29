using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleMultiThread
{
    class Methods
    {
    public    static void Method1(string name)
        {
            Console.WriteLine($"{name} Started");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{name}:" + i);
            }
            Console.WriteLine($"{name}  Ended");
        }

        public static void Method2(string name)
        {
            Console.WriteLine($"{name} Started");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{name}:" + i);
                if (i == 3)
                {
                    Console.WriteLine("Performing the Database Operation Started");
                    //Sleep for 10 seconds
                    System.Threading.Thread.Sleep(10000);
                    Console.WriteLine("Performing the Database Operation Completed");
                }
            }
            Console.WriteLine($"{name}  Ended");
        }
        public static void Method3(string name)
        {
            Console.WriteLine($"{name} Started");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{name}:" + i);
            }
            Console.WriteLine($"{name}  Ended");
        }
    }
}
