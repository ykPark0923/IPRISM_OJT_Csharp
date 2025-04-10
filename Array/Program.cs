using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace ArrayTest
{
    class MyList
    {
        private int[] array;

        public MyList()
        {
            array = new int[3];
        }

        public int this[int index]
        {
            get
            {
                return array[index];
            }

            set
            {
                if (index >= array.Length)
                {
                    Array.Resize<int>(ref array, index + 1);
                    Console.WriteLine($"Array Resized : {array.Length}");
                }
                array[index] = value;
            }
        }
        public int Length
        {
            get
            {
                return array.Length;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();
            for (int i = 0; i < 5; i++)
                list[i] = i;

            for (int i = 0; i < list.Length; i++)
                Console.WriteLine(list[i]);
            Hashtable ht = new Hashtable();
            ht["name"] = "Alice";
            ht["age"] = 25;

            Console.WriteLine("Hashtable 출력:");
            foreach (DictionaryEntry entry in ht)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict["language"] = "C#";
            dict["level"] = "Intermediate";

            Console.WriteLine("Dictionary 출력:");
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}