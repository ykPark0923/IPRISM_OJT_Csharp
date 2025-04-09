using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace ArrayTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 123, 456, 789 };

            ArrayList list = new ArrayList(arr);
            Stack stack = new Stack(arr);
            Queue queue = new Queue(arr);
        }
    }
}