using System;

namespace Property
{
    class BirthdayInfo
    {
        public required string Name
        {
            get; set;
        }

        public DateTime Birthday
        {
            get; init;
        }
        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year;
            }
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            BirthdayInfo birth = new BirthdayInfo { Name = "서현", Birthday = new DateTime(1991, 6, 28)};

            Console.WriteLine($"Name : {birth.Name}");
            Console.WriteLine($"Birthday : {birth.Birthday.ToShortDateString()}");
            Console.WriteLine($"Age : {birth.Age}");
        }
    }
}