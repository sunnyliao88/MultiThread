using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ConsoleMultiThread
{
    class Program
    {
        static void Main(string[] args)
        {
           // ThreadPerformance.ThreadPerformanceDemo();
            //Console.WriteLine("-------------");

           // TypeSafeThread.TypeSafeThreadDemo();
            //Console.WriteLine("-------------");

            //ThreadShareResource.ThreadShareResourceDemo();
            //Console.WriteLine("-------------");

           // TaskAndThread.TaskDemo();
            //Console.WriteLine("-------------");

            //TaskChain.TaskChainDemo();

           TaskAsync.TaskAsyncDemo();

            Console.ReadKey();
        }

    }
}