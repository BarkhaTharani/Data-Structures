using System;

namespace Data_Structures.Arrays {
    public class MergeSortedArraysInPlace {
        public static void Merge (int[] nums1, int m, int[] nums2, int n) {

            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;

            while (i >= 0 && j >= 0) {
                if (nums1[i] >= nums2[j]) {
                    nums1[k] = nums1[i];
                    i--;
                    k--;
                } else{
                    nums1[k] = nums2[j];
                    j--;
                    k--;
                } 
                
            }

            while (j >= 0) {
                nums1[k] = nums2[j];
                j--;
                k--;
            }

        }

        public static void Main (string[] args) {
            int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            int m = 3;
            int[] nums2 = { 2, 5, 6 };
            int n = 3;
            Merge (nums1, m, nums2, n);

            foreach (var a in nums1)
                Console.WriteLine (a);
        }
    }
}