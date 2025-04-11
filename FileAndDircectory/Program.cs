using System;
using System.Linq;
using System.IO; // 파일 및 디렉토리 관련 기능 제공
using System.Text.Json;
using System.Text;

namespace FileAndDircectory // 오타: Directory → Directory 로 수정하는 것이 좋음
{
    class NameCard
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var fileName = "a.json";

            using (Stream ws = new FileStream(fileName, FileMode.Create))
            {
                NameCard nc = new NameCard()
                {
                    Name = "박상현",
                    Phone = "010-123-4567",
                    Age = 33
                };

                string jsonString = JsonSerializer.Serialize<NameCard>(nc);
                byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonString);
                ws.Write(jsonBytes, 0, jsonBytes.Length);
            }

            using(Stream rs = new FileStream(fileName, FileMode.Open))
            {
                byte[] jsonBytes = new byte[rs.Length];
                rs.Read(jsonBytes, 0, jsonBytes.Length);
                string jsonString = System.Text.Encoding.UTF8.GetString(jsonBytes);

                NameCard nc2 = JsonSerializer.Deserialize<NameCard>(jsonString); 

                Console.WriteLine($"Name: {nc2.Name}");
                Console.WriteLine($"Phone: {nc2.Phone}");
                Console.WriteLine($"Age: {nc2.Age}");
            }
        }
    }
}
