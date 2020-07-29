using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMultiThread
{
    class TaskChain
    {
        public static void TaskChainDemo()
        {
            // int result = 0;
            Task<int> task = Task.Run(() => Accurate(10))
            .ContinueWith((p) => TwoTimes(p.Result));

            Console.WriteLine(task.Result);
        }

      static  int Accurate(int value)
        {
            int total = 0;
            for (int i = 0; i < value; i++)
            {
                total=total+i;
            }
            return total;
        }

        static int TwoTimes(int value)
        {
            int total = value*2;
           
            return total;
        }
    }
}
