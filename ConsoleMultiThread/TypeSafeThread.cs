using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleMultiThread
{
    class TypeSafeThread
    {
        //string _name;
        //Action<string> _callBack;

        //public TypeSafeThread(string name, Action<string> callBack)
        //{
        //    _name = name;
        //    _callBack = callBack;
        //}

        public static void TypeSafeThreadDemo()
        {
            var m1 = new TypeSafeMethod1("thread1", TypeSafeMethod1CallBack);
            var m2 = new TypeSafeMethod2("thread2");
            var m3 = new TypeSafeMethod3("thread3");

            Thread thread1 = new Thread(delegate () { m1.Method(); });
            Thread thread2 = new Thread(() => m2.Method());
            Thread thread3 = new Thread(m3.Method);

            thread1.Start();       
            thread2.Start();
            thread3.Start();

            thread2.Join();
            thread1.Join(20);
            thread3.Join();
        }

        public static void TypeSafeMethod1CallBack(string result)
        {
             Console.WriteLine($"{result} callback method invoked");
        }
      
    }

    class TypeSafeMethod1
    {
        string _name;
        Action<string> _callBack;

        public TypeSafeMethod1(string name, Action<string> callBack)
        {
            _name = name;
            _callBack = callBack;
        }

        public void Method()
        {
            Console.WriteLine($"{_name} Started");
            for (int i = 1; i <= 5; i++)
            {
                 Console.WriteLine($"{_name}:" + i);
            }
            Console.WriteLine($"{_name}  Ended");
           // _callBack($"{_name}");
            _callBack?.Invoke($"{_name}");
        }

    }
    class TypeSafeMethod2
    {
        string _name;
        public TypeSafeMethod2(string name)
        {
            this._name = name;
        }
        public void Method()
        {

            Console.WriteLine($"{_name} Started");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{_name}:" + i);
                if (i == 3)
                {
                    Console.WriteLine($"Performing the Database Operation Started, Thread {_name} Sleep...");
                
                    Thread.Sleep(1000);
                    Console.WriteLine($"Thread {_name} Waked up. Performing the Database Operation Completed");
                }
            }
            Console.WriteLine($"{_name}  Ended");
        }
    }

    class TypeSafeMethod3
    {
        string _name;
        public TypeSafeMethod3(string name)
        {
            this._name = name;
        }
        public void Method()
        {

            Console.WriteLine($"{_name} Started");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{_name}:" + i);
            }
            Console.WriteLine($"{_name}  Ended");
        }
    }
}
