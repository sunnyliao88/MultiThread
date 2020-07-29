using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleMultiThread
{
    class TaskAsync
    {
        public static  async Task TaskAsyncDemo()
        {
            
            Console.WriteLine($"main thread starts {Thread.CurrentThread.ManagedThreadId}");
            var result = await CallMe("nnn");
            var resultAgain = await CallMeAgain("nnn");
            Console.WriteLine(result);
            Console.WriteLine(resultAgain);

            //var result = CallMe("nnn");
            //var resultAgain = CallMeAgain("nnn");
            //Console.WriteLine(result.Result);
            //Console.WriteLine(resultAgain.Result);
            Console.WriteLine("main thread ends");
        }

        static Task<string> CallMe(string name)
        {         
            Task<string> task = new Task<string>(() => GetResult(name));
            task.Start();
            return task;
        }

        static Task<string> CallMeAgain(string name)
        {          
            Task<string> task = new Task<string>(() => GetResult(name+"again"));
            task.Start();
            return task;
        }
        static string GetResult(string name)
        {
            for (int i=0; i<500;i++) {
                if (i%50==0) {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}--{i}");
                }
            }
            Console.WriteLine($"running in child thread, threadid: {Thread.CurrentThread.ManagedThreadId}");
            return $"{name} is my name";
        }
    }
}
