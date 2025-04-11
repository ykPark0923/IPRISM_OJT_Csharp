using System;

namespace Exception_
{
    internal class Program
    {

        static void Main(string[] args)
        {
            try
            {
                // Nullable int 타입 변수 a 선언하고 null 할당 (a는 값이 없음을 의미)
                int? a = null;

                // a가 null이 아니면 a의 값을 b에 할당하고,
                // a가 null이면 ArgumentNullException 예외를 던짐
                int b = a ?? throw new ArgumentNullException();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                int[] array = new[] { 1, 2, 3 };
                int index = 4;
                int value = array[index >= 0 && index < 3 ? index : throw new IndexOutOfRangeException()];
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}