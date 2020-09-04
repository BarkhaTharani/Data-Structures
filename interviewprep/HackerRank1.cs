using System;

namespace Data_Structures.Interviewprep {
    public class HackerRank1 {
        public static void fizzBuzz (int n) {
            for(int i = 1; i <= n; i++) {
                if( isMultipleOfThree(i) && isMultipleOfFive(i)) {
                    Console.WriteLine("FizzBuzz");
                } 
                else if (isMultipleOfThree(i) && !isMultipleOfFive(i))
                {
                    Console.WriteLine("Fizz");
                } 
                else if (isMultipleOfFive(i) && !isMultipleOfThree(i))
                {
                     Console.WriteLine("Buzz");
                } 
                else {
                    Console.WriteLine(i);
                }
            }
        }

        public static bool isMultipleOfThree (int n) 
        {
            if (n % 3 == 0)
                return true;
            return false;
        } 

        public static bool isMultipleOfFive (int n) 
        {
            if (n % 5 == 0)
                return true;
            return false;
        } 

    }
}