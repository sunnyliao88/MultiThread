using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleMultiThread
{
    class TaskAndThread
    {

        public static void TaskDemo()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Statred");

            //Task<string> task =new Task<string>(TaskMethod,"task parameter");
           
            Task<string> task = new Task<string>(()=>TaskMethod("task parameter"));
            task.Start();
            Console.WriteLine(task.Result);
            //  task.Wait();

            Thread thread = new Thread(ThreadMethod);
            thread.Start("thread parameter");           

            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            ThreadPool.QueueUserWorkItem((o) => { ThreadPoolMethod(o); autoResetEvent.Set(); });

       
            thread.Join();
            autoResetEvent.WaitOne();

            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");

        }




        public static string TaskMethod(object input)
        {
            Thread.Sleep(1000);      
            var t = Thread.CurrentThread;
            string result = $"---Child Task Started. ThreadId: {t.ManagedThreadId};  IsBackground: {t.IsBackground};  IsThreadPoolThread:{t.IsThreadPoolThread}; input: {input}";
           // Console.WriteLine(result);
            return result;
        }

        public static void ThreadMethod(object input)
        {
            Thread.Sleep(1000);
            var t = Thread.CurrentThread;
            string result = $"---Child Task Started. ThreadId: {t.ManagedThreadId};  IsBackground: {t.IsBackground};  IsThreadPoolThread:{t.IsThreadPoolThread}; input: {input}";
            Console.WriteLine(result);

        }
        public static void ThreadPoolMethod(object o)
        {
            Thread.Sleep(1000);
            var t = Thread.CurrentThread;
            Console.WriteLine($"---Child ThreadPool Thread Started. ThreadId: {t.ManagedThreadId};  IsBackground: {t.IsBackground};  IsThreadPoolThread:{t.IsThreadPoolThread}");

        }

    }
}
