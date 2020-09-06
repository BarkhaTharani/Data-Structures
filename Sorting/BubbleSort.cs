using System;

namespace Data_Structures.Sorting {
    public class BubbleSort {
        public static int[] Sort (int[] arr) {
            int len = arr.Length;

            for (int i = 0; i < len - 1; i++) {
                for (int j = 0; j < len - i - 1; j++) {
                    if (arr[j] > arr[j + 1]) {
                        Swap (arr, j, j + 1);
                    }
                }

            }
            return arr;
        }

        public static void Swap (int[] arr, int i, int j) {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void Main (string[] args) {
            int[] arr = { 5, 8, 1, 4, 9 };
            Sort (arr);

            foreach (var a in arr)
                Console.WriteLine (a + " ");
        }
    }
}