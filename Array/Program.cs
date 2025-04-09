using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace ArrayTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue que = new Queue();
            que.Enqueue(1);
            que.Enqueue(1);
            que.Enqueue(1);
            que.Enqueue(1);
            que.Enqueue(1);
            que.Enqueue(1);
            que.Enqueue(1);
            que.Enqueue(1);

            while(que.Count > 0)
            {
                Console.WriteLine(que.Dequeue());
            }
        }
    }
}