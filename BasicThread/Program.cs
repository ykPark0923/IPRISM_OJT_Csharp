using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BasicThread
{
    internal class Program
    {
        // 비동기 메서드 정의: 호출한 쪽(Main → Caller)은 이 메서드가 완료될 때까지 기다리지 않음.
        async static private void MyMethodAsync(int count)
        {
            Console.WriteLine("C"); // 출력 3
            Console.WriteLine("D"); // 출력 4

            // 비동기 작업 시작: 별도 스레드에서 루프를 돌며 0.1초마다 출력
            await Task.Run(async () =>
            {
                for (int i = 1; i <= count; i++)
                {
                    Console.WriteLine($"{i}/{count} ..."); // 출력 5~7: 1/3, 2/3, 3/3
                    await Task.Delay(100); // 비동기 지연 (CPU 점유 X)
                }
            });

            // 비동기 루프가 끝난 후 실행되는 코드
            Console.WriteLine("G"); // 출력 8
            Console.WriteLine("H"); // 출력 9
        }

        // Caller 함수는 MyMethodAsync를 호출하지만, await 하지 않기 때문에 다음 줄을 바로 실행
        static void Caller()
        {
            Console.WriteLine("A"); // 출력 1
            Console.WriteLine("B"); // 출력 2

            MyMethodAsync(3); // 비동기 호출 (await 하지 않음 → 바로 다음 줄 실행)

            Console.WriteLine("E"); // 출력 5 (MyMethodAsync의 루프와 거의 동시에 실행될 수 있음)
            Console.WriteLine("F"); // 출력 6
        }

        static void Main(string[] args)
        {
            Caller(); // Caller 실행

            Console.ReadLine(); // 콘솔 창 유지 → 비동기 출력이 끝날 때까지 사용자 입력 대기
        }
    }
}
