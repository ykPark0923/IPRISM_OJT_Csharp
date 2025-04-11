using System;
using System.Threading; // Thread 클래스 사용을 위한 네임스페이스

namespace BasicThread
{
    internal class Program
    {
        // 쓰레드에서 실행할 메서드 정의
        static void DoSomething()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"DoSomething : {i}"); // DoSomething 스레드의 작업 출력
                Thread.Sleep(10); // 10ms 동안 일시 정지 (CPU 양보)
            }
        }

        static void Main(string[] args)
        {
            // 새로운 쓰레드 생성, 실행 메서드는 DoSomething
            Thread t1 = new Thread(new ThreadStart(DoSomething));
            // 위 구문은 아래와 같이 간단히 쓸 수도 있어요:
            // Thread t1 = new Thread(DoSomething);

            Console.WriteLine("Starting thread...");
            t1.Start(); // t1 쓰레드 시작 → DoSomething 실행됨

            // 메인 쓰레드에서 동시에 작업 수행
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main :{i}"); // 메인 스레드의 작업 출력
                Thread.Sleep(10); // 10ms 쉬기 (스레드 간 번갈아 실행 보기 좋게 하기 위함)
            }

            Console.WriteLine("Waiting until thread stops...");
            t1.Join(); // t1 스레드가 끝날 때까지 Main 스레드 대기

            Console.WriteLine("Finished"); // 모든 스레드 종료 후 출력
        }
    }
}
