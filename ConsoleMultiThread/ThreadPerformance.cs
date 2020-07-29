using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleMultiThread
{
    class ThreadPerformance
    {
        public static void ThreadPerformanceDemo()
        {
            //Singal thread
            Stopwatch sw = new Stopwatch();
            sw.Start();
            EvenNumbersSum();
            OddNumbersSum();
            sw.Stop();
            Console.WriteLine($"***Total time in milliseconds : {sw.ElapsedMilliseconds}");

            //Manually created thread         
            sw.Reset();
            sw.Start();
            Thread th1 = new Thread(EvenNumbersSum);
            Thread th2 = new Thread(OddNumbersSum);
            th1.Start();
            th2.Start();
            th1.Join();
            th2.Join();
            sw.Stop();
            Console.WriteLine($"***Total time in milliseconds : {sw.ElapsedMilliseconds}");

            //Threrad pool thread      
            sw.Reset();
            sw.Start();
            ManualResetEvent myWaitHandle1 = new ManualResetEvent(false);
            ManualResetEvent myWaitHandle2 = new ManualResetEvent(false);         

            ThreadPool.QueueUserWorkItem((o) => { EvenNumbersSum(); myWaitHandle1.Set(); });
            ThreadPool.QueueUserWorkItem(OddNumbersSum_o, myWaitHandle2);

            myWaitHandle1.WaitOne();           
            myWaitHandle2.WaitOne();
            myWaitHandle2.Set();
            sw.Stop();
            Console.WriteLine($"***Total time in milliseconds : {sw.ElapsedMilliseconds}");
          
        }

        public static void EvenNumbersSum()
        {
            double Evensum = 0;
            for (int count = 0; count <= 50000000; count++)
            {
                if (count % 2 == 0)
                {
                    Evensum = Evensum + count;
                }
            }
            Console.WriteLine($"Sum of even numbers = {Evensum}");
        }
        public static void OddNumbersSum()
        {
            double Oddsum = 0;
            for (int count = 0; count <= 50000000; count++)
            {
                if (count % 2 == 1)
                {
                    Oddsum = Oddsum + count;
                }
            }
            Console.WriteLine($"Sum of odd numbers = {Oddsum}");
        } 
        public static void OddNumbersSum_o(object o)
        {
            ManualResetEvent waitHandleFromParent = (ManualResetEvent)o;
            double Oddsum = 0;
            for (int count = 0; count <= 50000000; count++)
            {
                if (count % 2 == 1)
                {
                    Oddsum = Oddsum + count;
                }
            }
            waitHandleFromParent.Set();
            Console.WriteLine($"Sum of odd numbers = {Oddsum}");
        }

    }
}
