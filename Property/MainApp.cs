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
            CTransaction trA = new CTransaction
            {
                From = "Alice",
                To = "Bob",
                Amount = 100
            };

            CTransaction trB = new CTransaction
            {
                From = "Alice",
                To = "Bob",
                Amount = 100
            };

            Console.WriteLine(trA);
            Console.WriteLine(trB);


            //기본 equals()의 기본 구현은 내용 비교가 아닌 참고를 비교하므로 false출력
            Console.WriteLine($"{trA.Equals(trB)}");





            RTransaction tr1 = new RTransaction
            {
                From="Alice", To="Bob", Amount=100
            };

            RTransaction tr2 = new RTransaction
            {
                From = "Alice",
                To = "Bob",
                Amount = 100
            };



            Console.WriteLine(tr1);
            Console.WriteLine(tr2);
            Console.WriteLine($"{tr1.Equals(tr2)}");
        }
    }
}