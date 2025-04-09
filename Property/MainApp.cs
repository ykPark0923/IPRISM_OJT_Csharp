using System;
using System.Diagnostics;

namespace Property
{
    class CTransaction
    {
        public string From { get; init; }
        public string To { get; init; }
        public int Amount { get; init; }

        public override string ToString()
        {
            return $"{From, -10}->{To,-10}: ${Amount}";
        }
    }

    record RTransaction
    {
        public string From { get; init; }
        public string To { get; init; }
        public int Amount { get; init; }

        public override string ToString()
        {
            return $"{From,-10}->{To,-10}: ${Amount}";
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            var a = new { Name = "박상현", Age = 123 };
            Console.WriteLine($"Name:{a.Name}, Age:{a.Age}");

            var b = new { Subject = "수학", Scores = new int[] { 90, 80, 7, 60 } };

            Console.Write($"Subject:{b.Subject}, Scores:");
            foreach(var score in b.Scores)
            {
                Console.Write($"{score} ");
            }
            Console.WriteLine();
        }
    }
}