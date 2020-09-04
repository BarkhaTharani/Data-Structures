using System;

namespace Data_Structures.Interviewprep {
    public class ArrayLeftRotation {
        
        // using iterative approach, complexity n^2 // bad approach
        static int[] RotLeft (int[] a, int d) {
            
            if(d == a.Length)
                return a;

            d = d % a.Length;
            
            for (int i = 0; i < d; i++) {
                int temp = a[0];
                for (int j = 0; j < a.Length - 1; j++) {
                    a[j] = a[j + 1];                    
                }

                a[a.Length-1] = temp;                

            }

            return a;
        }


        // complexity O(n)- best approach
        public static int[] RotateArray (int[] a, int d) {
            int len = a.Length;
            if(d == len)
                return a;

            d = d % len;
            
            ReverseArray(a, 0, d-1); //reverse left subarray
            ReverseArray(a, d, len-1); // reverse right subarray
            ReverseArray(a, 0, len-1);  //reverse entire array  

            return a;
        }

        public static int[] ReverseArray (int[] s, int i, int j) {
           
            while (i < j) {
                Swap (s, i, j);
                i++;
                j--;
            }

            return s;
        }

        public static void Swap (int[] n, int i, int j) {
            var temp = n[i];
            n[i] = n[j];
            n[j] = temp;
        }
        public static void Main (string[] args) {
            int[] arr = { 5, 4, 3, 2, 1 };
            var res = RotateArray (arr, 2);

            foreach (var item in arr)
                Console.Write (item + " ");
        }
    }

}