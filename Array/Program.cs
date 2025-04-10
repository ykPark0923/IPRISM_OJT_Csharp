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