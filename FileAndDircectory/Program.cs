using System;
using System.Linq;
using System.IO; // 파일 및 디렉토리 관련 기능 제공

namespace FileAndDircectory // 오타: Directory → Directory 로 수정하는 것이 좋음
{
    internal class Program
    {
        // 잘못된 타입이 입력됐을 때 호출되는 함수
        static void OnWrongPathType(string type)
        {
            Console.WriteLine($"{type} is wrong type"); // 에러 메시지 출력
            return;
        }

        static void Main(string[] args)
        {
            // 인자가 아무것도 없을 경우 사용법 안내 메시지 출력
            if (args.Length == 0)
            {
                Console.WriteLine("Usage : Touch.exe <Path> [Type:File/Directory]");
                return;
            }

            // 첫 번째 인자: 대상 경로
            string path = args[0];

            // 두 번째 인자: 타입 (기본값은 "File")
            string type = "File";
            if (args.Length > 1) type = args[1];

            // 지정한 경로가 파일 또는 디렉토리로 존재하는 경우
            if (File.Exists(path) || Directory.Exists(path))
            {
                // 파일일 경우: 마지막 수정 시간을 현재 시각으로 갱신
                if (type == "File")
                    File.SetLastWriteTime(path, DateTime.Now);

                // 디렉토리일 경우: 마지막 수정 시간을 현재 시각으로 갱신
                else if (type == "Directory")
                    Directory.SetLastWriteTime(path, DateTime.Now);

                // 둘 다 아닌 경우: 잘못된 타입 처리
                else
                {
                    OnWrongPathType(type); // 여기 원래는 type을 넘겨야 의미 맞음
                    return;
                }

                Console.WriteLine($"Updated {path} {type}"); // 업데이트 완료 메시지
            }
            else // 경로가 존재하지 않는 경우 → 새로 생성
            {
                // 파일 생성
                if (type == "File")
                    File.Create(path).Close(); // Create는 스트림 반환 → Close() 필요

                // 디렉토리 생성
                else if (type == "Directory")
                    Directory.CreateDirectory(path);

                // 잘못된 타입
                else
                {
                    OnWrongPathType(type);
                    return;
                }

                Console.WriteLine($"Created {path} {type}"); // 생성 완료 메시지
            }
        }
    }
}
