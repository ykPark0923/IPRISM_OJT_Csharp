using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace ArrayTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            for(int i=0; i<5; i++) list.Add(i);

            foreach(object obj in list)
            {
                Console.Write($"{obj} ");
            }
            Console.WriteLine();




            list.RemoveAt(2);
            foreach (object obj in list)
            {
                Console.Write($"{obj} ");
            }
            Console.WriteLine();



            list.Insert(2, 2);
            foreach (object obj in list)
            {
                Console.Write($"{obj} ");
            }
            Console.WriteLine();

        }
    }
}