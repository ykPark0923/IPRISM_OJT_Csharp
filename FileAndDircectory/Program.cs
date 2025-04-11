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
                var list = new List<NameCard>();
                list.Add(new NameCard() { Name="박상현", Phone="010-123-4567", Age =33});
                list.Add(new NameCard() { Name = "김연아", Phone = "010-323-1111", Age = 32 });
                list.Add(new NameCard() { Name = "장미란", Phone = "010-555-5555", Age = 39 });

                string jsonString = JsonSerializer.Serialize<List<NameCard>>(list);
                byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonString);
                ws.Write(jsonBytes, 0, jsonBytes.Length);
            }

            using(Stream rs = new FileStream(fileName, FileMode.Open))
            {
                byte[] jsonBytes = new byte[rs.Length];
                rs.Read(jsonBytes, 0, jsonBytes.Length);
                string jsonString = System.Text.Encoding.UTF8.GetString(jsonBytes);

                var list2 = JsonSerializer.Deserialize<List<NameCard>>(jsonString); 

                foreach(NameCard nc in list2)
                {
                    Console.WriteLine($"Name:{nc.Name}, Phone:{nc.Phone}, Age:{nc.Age}");                    
                }
            }
        }
    }
}
