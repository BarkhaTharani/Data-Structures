using System;
using System.Collections.Generic;

namespace data_structures.interviewprep {
    public class BalancedStack {

        public static bool IsBalanced (string s) {
            Stack<char> stack = new Stack<char> ();

            for (int i = 0; i < s.Length; i++) {
                var currChar = s[i];
                if (currChar == '(' || currChar == '{' || currChar == '[') {
                    stack.Push (currChar);
                    continue;
                }
                if (currChar == ')' || currChar == '}' || currChar == ']') {
                    if (stack.Count == 0)
                        return false;
                    var topElem = stack.Pop ();
                    if ((topElem == '(' && currChar == ')') || (topElem == '{' && currChar == '}') ||
                        (topElem == '[' && currChar == ']')) {
                        continue;
                    } else {
                        return false;
                    }
                }
            }

            return stack.Count == 0;

        }

        public static void Main (string[] args) {
            String s1 = "()";
            Console.WriteLine (IsBalanced (s1));
        }

    }

}