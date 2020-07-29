using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleMultiThread
{
    // not good example
    class ThreadShareResource
    {

        public static void ThreadShareResourceDemo()
        {
            ShareResource shareResource = new ShareResource(15, Callback);
            Thread thr1 = new Thread(shareResource.Add);
            Thread thr2 = new Thread(shareResource.Add);
            thr1.Start();
            thr2.Start();
            thr1.Join();
            thr2.Join();
            Console.WriteLine($"main thread  {shareResource._count}");
            Console.WriteLine("***main thread end");

        }


        public static void Callback(string result)
        {
            Console.WriteLine(result);
        }
    }

    class ShareResource
    {

        private readonly static object _lock = new object();
        public int _count = 0;
        int _increment;
        Action<string> _callback;

        public ShareResource(int increment, Action<string> callback)
        {
            _increment = increment;
            _callback = callback;
        }
        public void Add()
        {
            int id = Thread.CurrentThread.ManagedThreadId;

            for (int i = 0; i < _increment; i++)
            {
                try
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Trying to enter into the critical section");
                    //  lock (_lock)
                    Monitor.Enter(_lock);
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Entered into the critical section");
                    {
                        _count++;
                    }
                }
                finally
                {
                    Monitor.Exit(_lock);
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Exit from critical section");
                }
            }
            _callback?.Invoke(_count.ToString());

        }
    }
}
