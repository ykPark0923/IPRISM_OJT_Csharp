using System;
using System.Threading; // Thread 클래스 사용을 위한 네임스페이스
using System.Security.Permissions; // (현재 코드에서 사용되지 않음, 생략 가능)

namespace BasicThread
{
    // 공유 자원을 증가/감소시킬 작업 클래스 정의
    class Counter
    {
        const int LOOP_COUNT = 1000; // 증가/감소 루프 횟수 (상수)

        readonly object thisLock; // 임계 영역 보호를 위한 lock 객체
        bool lockedCount = false;

        private int count; // 공유 자원 (스레드 간 충돌 방지를 위해 lock 필요)

        // count 값을 읽을 수 있게 하는 속성 (읽기 전용)
        public int Count
        {
            get { return count; }
        }

        // 생성자
        public Counter()
        {
            thisLock = new object(); // lock에 사용할 객체 초기화
            count = 0;               // count 초기값 설정
        }

        // count를 1씩 증가시키는 메서드
        public void Increase()
        {
            int loopCount = LOOP_COUNT;

            while (loopCount-- > 0)
            {

                lock (thisLock)
                {
                    while (count > 0 || lockedCount == true)
                    {
                        Monitor.Wait(thisLock);
                    }

                    lockedCount = true;
                    count++;
                    lockedCount = false;

                    Monitor.Pulse(thisLock);
                }
            }
        }

        // count를 1씩 감소시키는 메서드
        public void Decrease()
        {
            int loopCount = LOOP_COUNT;

            while (loopCount-- > 0)
            {
                lock (thisLock)
                {
                    while (count < 0 || lockedCount == true)
                    {
                        Monitor.Wait(thisLock);
                    }

                    lockedCount = true;
                    count--;
                    lockedCount = false;

                    Monitor.Pulse(thisLock);
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Counter 클래스 인스턴스 생성 (공유 자원)
            Counter task = new Counter();

            // Increase 메서드를 실행할 스레드 생성
            Thread indcThread = new Thread(task.Increase);

            // Decrease 메서드를 실행할 스레드 생성
            Thread decThread = new Thread(task.Decrease);

            // 두 스레드 시작
            indcThread.Start();
            decThread.Start();

            // 두 스레드가 종료될 때까지 메인 스레드 대기
            indcThread.Join();
            decThread.Join();

            // 최종 count 값 출력 (정상적으로 동기화되었으면 0이어야 함)
            Console.WriteLine(task.Count);
        }
    }
}
