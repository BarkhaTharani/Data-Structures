using System;

namespace Data_Structures.Arrays {
    public class SearchArray {
        public static int LinearSearch (int[] arr, int key) {
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] == key)
                    return i;

            }
            return -1;
        }

        public static int BinarySearch (int[] arr, int key, int start, int end) {
            int mid = (start + end) / 2;

            if (start <= end) {
                if (key == arr[mid]) {
                    return mid;
                }
                if (key < arr[mid]) {
                    return BinarySearch (arr, key, start, mid - 1);
                }
                if (key > arr[mid]) {
                    return BinarySearch (arr, key, mid + 1, end);
                }
            }

            return -1;

        }

        public static void Main (string[] args) {
            int[] arr = { 6, 14, 8, 1, 0, 9 };
            var pos = BinarySearch (arr, 9, 0, arr.Length - 1);
            if (pos > 0) {
                Console.WriteLine ("Element found at index: " + pos);
            } else {
                Console.WriteLine ("Element not found");
            }

        }
    }
}