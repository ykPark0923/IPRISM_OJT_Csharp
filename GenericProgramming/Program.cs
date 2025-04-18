using System;

namespace GenericProgramming
{
    // 제네릭 클래스 MyList<T> 정의
    class MyList<T>
    {
        // 제네릭 타입 T의 요소를 저장할 배열
        private T[] array;

        // 생성자: MyList 클래스의 인스턴스를 생성할 때, 초기 크기 3인 배열을 할당
        public MyList()
        {
            array = new T[3];  // 기본 배열 크기 3
        }

        // 인덱서: MyList 객체의 요소에 인덱스를 통해 접근할 수 있도록 함
        public T this[int index]
        {
            get { return array[index]; }  // 배열에서 해당 인덱스의 값을 반환

            set
            {
                // 배열의 크기가 인덱스보다 작으면 배열 크기를 증가시킴
                if (index >= array.Length)
                {
                    // 배열의 크기를 (index + 1)로 증가시키면서 리사이즈
                    Array.Resize<T>(ref array, index + 1);
                    // 리사이즈된 배열 크기를 출력
                    Console.WriteLine($"Array Resized: {array.Length}");
                }

                // 지정된 인덱스에 값 설정
                array[index] = value;
            }
        }

        // Length 프로퍼티: 배열의 길이를 반환
        public int Length
        {
            get { return array.Length; }
        }
    }

    // 프로그램의 시작점을 담당하는 클래스
    public class Program
    {
        // Main 메서드: 프로그램 실행 시작 지점
        static void Main(string[] args)
        {
            // MyList<string> 타입의 인스턴스 생성
            MyList<string> str_list = new MyList<string>();

            // MyList<string>의 각 인덱스에 값을 할당
            str_list[0] = "abc";
            str_list[1] = "def";
            str_list[2] = "ghi";
            // 배열의 크기가 자동으로 증가하면서 4번째 요소와 5번째 요소에 값 할당
            str_list[3] = "jkl";
            str_list[4] = "mno";

            // MyList<string>의 값을 출력
            for (int i = 0; i < str_list.Length; i++)
            {
                Console.WriteLine(str_list[i]);
            }
            Console.WriteLine();  // 출력 구분을 위한 공백

            // MyList<int> 타입의 인스턴스 생성
            MyList<int> int_list = new MyList<int>();

            // MyList<int>의 각 인덱스에 값을 할당
            int_list[0] = 0;
            int_list[1] = 1;
            int_list[2] = 2;
            // 배열의 크기가 자동으로 증가하면서 4번째 요소와 5번째 요소에 값 할당
            int_list[3] = 3;
            int_list[4] = 4;

            // MyList<int>의 값을 출력
            for (int i = 0; i < int_list.Length; i++)
            {
                Console.WriteLine(int_list[i]);
            }
        }
    }
}
