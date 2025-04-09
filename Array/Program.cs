using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace ArrayTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht["book"] = "책";
            ht["cook"] = "요리사";
            ht["tweet"] = "지저귀다";

            Console.WriteLine(ht["book"]);
            Console.WriteLine(ht["cook"]);
            Console.WriteLine(ht["tweet"]);
        }
    }
}