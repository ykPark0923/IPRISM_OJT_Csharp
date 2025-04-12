using System;
using System.IO;
using System.Text;

namespace VisionIndexerFileStreamExample
{
    // 검사 결과를 배열로 관리할 수 있는 클래스 정의
    class DefectResults
    {
        // 내부적으로 최대 10개의 검사 결과를 저장할 수 있는 배열
        private string[] results = new string[10];

        // 인덱서를 통해 외부에서 마치 배열처럼 접근할 수 있도록 구현
        public string this[int index]
        {
            get => results[index];   // 인덱스 값을 가져올 때
            set => results[index] = value; // 인덱스에 값을 설정할 때
        }

        // 검사 결과를 파일로 저장하는 메서드
        public void SaveToFile(string path)
        {
            // StreamWriter를 사용하여 파일을 UTF-8로 열고 덮어쓰기 모드로 씀
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                for (int i = 0; i < results.Length; i++)
                {
                    // null 또는 빈 문자열은 저장하지 않음
                    if (!string.IsNullOrEmpty(results[i]))
                        writer.WriteLine($"{i}: {results[i]}");  // "0: OK" 형태로 저장
                }
            }
        }

        // 저장된 파일에서 검사 결과를 읽어오는 메서드
        public void LoadFromFile(string path)
        {
            // 파일이 존재하지 않으면 아무 것도 하지 않음
            if (!File.Exists(path))
                return;

            // StreamReader를 사용하여 UTF-8 텍스트 파일을 읽음
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    // 줄을 ":" 기준으로 나누어 [인덱스, 값] 형태로 분리
                    string[] parts = line.Split(":");
                    if (parts.Length == 2 &&
                        int.TryParse(parts[0].Trim(), out int index))
                    {
                        // 인덱스가 정수로 잘 파싱되면 해당 위치에 결과 저장
                        this[index] = parts[1].Trim(); // 예: results[1] = "NG"
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // 검사 결과를 저장할 파일 경로 정의
            string filePath = "results.txt";

            // DefectResults 객체 생성 및 결과 입력
            DefectResults results = new DefectResults();
            results[0] = "OK";
            results[1] = "NG";
            results[2] = "OK";

            // 파일로 저장
            results.SaveToFile(filePath);
            Console.WriteLine("결과를 파일로 저장했습니다.");

            // 새로운 객체를 생성하여 파일에서 결과 불러오기
            DefectResults loadedResults = new DefectResults();
            loadedResults.LoadFromFile(filePath);
            Console.WriteLine("\n파일에서 불러온 결과:");

            // 불러온 결과를 화면에 출력
            for (int i = 0; i < 10; i++)
            {
                if (!string.IsNullOrEmpty(loadedResults[i]))
                    Console.WriteLine($"{i}번 결과: {loadedResults[i]}");
            }

            // 프로그램 종료 전 콘솔 멈춤
            Console.ReadLine();
        }
    }
}
