using System;
using System.Runtime.CompilerServices;

namespace ArrayTest
{
    internal class Program
    {
        static void PrintArray(System.Array array)
        {
            foreach (var e in array) Console.Write(e);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // 'Z' - 'A' + 1 = 90-65+1 = 26
            char[] array = new char['Z' - 'A' + 1];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (char)('A' + i);
            }

            PrintArray(array[..]);
            PrintArray(array[5..]);

            Range range_5_10 = 5..10;
            PrintArray(array[range_5_10]);

            //뒤에서 0번째, 즉 마지막까지
            Index last = ^0;
            Range range_5_last = 5..last;

            PrintArray(array[range_5_last]);

            // 뒤에서 4번째부터 뒤에서 1번째까지
            PrintArray(array[^4..^1]);
        }
    }
}