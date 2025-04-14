using System;
using System.Threading; // Thread 클래스 사용을 위한 네임스페이스
using System.Security.Permissions;

namespace BasicThread
{
    class Counter
    {
        const int LOOP_COUNT = 1000;

        readonly object thisLock;

        private int count;

        public int Count
        {
            get { return count; }
        }

        public Counter()
        {
            thisLock = new object();
            count = 0;
        }

        public void Increase()
        {
            int loopCount = LOOP_COUNT;

            while (loopCount-- > 0)
            {
                lock (thisLock)
                {
                    count++;
                }
                Thread.Sleep(1);
            }
        }
        public void Decrease()
        {
            int loopCount = LOOP_COUNT;

            while (loopCount-- > 0)
            {
                lock (thisLock)
                {
                    count--;
                }
                Thread.Sleep(1);
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Counter task = new Counter();
            Thread indcThread = new Thread(task.Increase);
            Thread decThread = new Thread(task.Decrease);


            indcThread.Start();
            decThread.Start();


            indcThread.Join();
            decThread.Join();

            Console.WriteLine(task.Count);
        }
    }
}
