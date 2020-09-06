using System;

namespace Data_Structures.Sorting {
    public class InsertionSort {
        public static void Sort (int[] arr) {
            int n = arr.Length;
            for (int i = 1; i < n; i++) {
                int curr = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > curr) {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j+1] = curr;
            }
        }

        public static void Main(string[] args) {
            int[] arr = {1 , 0, 5, 6, 2, 9};

            Sort(arr);

            foreach(var a in arr) {
                Console.Write(a + " ");
            }
        }
    }
}