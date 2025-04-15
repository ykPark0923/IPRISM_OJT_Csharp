using System;

namespace Delegate
{
    delegate int Compare(int a, int b);

    internal class Program
    {
        static int AscendCompare(int a, int b)
        {
            if (a > b) return 1;
            else if (a == b) return 0;
            else return -1;
        }

        // 내림차순 비교 함수: a가 b보다 작으면 1, 같으면 0, 크면 -1 반환
        static int DescendCompare(int a, int b)
        {
            if (a < b) return 1;
            else if (a == b) return 0;
            else return -1;
        }

        // 버블 정렬 함수: 배열과 비교 델리게이트를 받아서 해당 기준에 따라 정렬 수행
        static void BubbleSort(int[] DataSet, Compare Comparer)
        {
            int i = 0;
            int j = 0;
            int temp = 0;

            // 바깥 루프는 전체 패스를 반복 (전체 길이 - 1만큼 반복)
            for (i = 0; i < DataSet.Length - 1; i++)
            {
                // 안쪽 루프는 인접한 요소를 비교하고, 조건에 따라 교환
                // 이미 정렬된 마지막 i개는 제외
                for (j = 0; j < DataSet.Length - (i + 1); j++)
                {
                    // Comparer 델리게이트를 사용하여 두 요소를 비교
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        // 순서가 잘못된 경우, 두 요소의 값을 교환
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            // 첫 번째 정렬: 오름차순
            int[] array = { 3, 7, 4, 2, 10 };

            Console.WriteLine("Sorting ascending....");

            // BubbleSort 호출 시, AscendCompare 메서드를 델리게이트로 전달
            BubbleSort(array, new Compare(AscendCompare));

            // 정렬된 결과 출력
            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");

            // 두 번째 정렬: 내림차순
            int[] array2 = { 7, 2, 8, 10, 11 };

            Console.WriteLine("\nSorting descending....");

            // BubbleSort 호출 시, DescendCompare 메서드를 델리게이트로 전달
            BubbleSort(array2, new Compare(DescendCompare));

            // 정렬된 결과 출력
            for (int i = 0; i < array2.Length; i++)
                Console.Write($"{array2[i]} ");

            Console.WriteLine(); // 줄바꿈
        }
    }
}
