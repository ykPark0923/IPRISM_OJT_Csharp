using System;
using System.Threading; // Thread 클래스와 관련 기능을 사용하기 위한 네임스페이스

namespace BasicThread
{
    // 별도의 작업을 수행할 클래스를 정의
    class SideTask
    {
        int count; // 카운트다운에 사용할 변수

        // 생성자를 통해 초기 카운트 값을 전달받음
        public SideTask(int count)
        {
            this.count = count;
        }

        // 스레드에서 실행될 메서드
        public void KeepAlive()
        {
            try
            {
                // count가 0이 될 때까지 반복
                while (count > 0)
                {
                    Console.WriteLine($"{count--} left"); // 남은 횟수 출력 후 1 감소
                    Thread.Sleep(10); // 10ms 동안 스레드 일시 중지 (CPU 양보)
                    Console.WriteLine("Count : 0"); // 의도하지 않은 위치에 출력 (반복문 안에 위치하여 매번 출력됨)
                }
            }
            catch (ThreadAbortException e)
            {
                // 스레드가 Abort() 메서드에 의해 종료될 때 발생하는 예외 처리
                Console.WriteLine(e); // 예외 내용 출력
                Thread.ResetAbort(); // 스레드 종료 요청 취소 (예외를 무시하고 계속 실행할 수 있도록)
            }
            finally
            {
                // 스레드 종료 전 자원 정리 작업
                Console.WriteLine("Clearning resource...");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 작업을 수행할 객체 생성, 카운트는 100부터 시작
            SideTask task = new SideTask(100);

            // 새로운 스레드를 생성하고, 실행할 메서드를 지정
            Thread t1 = new Thread(new ThreadStart(task.KeepAlive));

            // 백그라운드 스레드 여부 설정 (false는 포그라운드 스레드, 주 스레드 종료 후에도 계속 실행됨)
            t1.IsBackground = false;

            Console.WriteLine("Starting thread...");
            t1.Start(); // 스레드 시작, KeepAlive() 메서드 실행됨

            Thread.Sleep(100); // 메인 스레드 100ms 동안 대기 (t1이 조금 실행되도록 유도)

            Console.WriteLine("Aborting thread...");
            t1.Abort(); // 스레드 강제 종료 요청 (비추천 방식, 예외 발생시킴)

            Console.WriteLine("Waiting until thread stops...");
            t1.Join(); // t1 스레드가 종료될 때까지 대기 (메인 스레드는 여기서 대기함)

            Console.WriteLine("Finished"); // 모든 작업 완료 메시지 출력
        }
    }
}
