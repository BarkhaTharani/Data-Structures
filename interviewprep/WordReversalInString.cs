using System;
using System.Collections.Generic;

namespace Data_Structures.Interviewprep {
    public class WordReversalInString {
        public string ReverseWords (string s) {
            string[] words = s.Split (" ");
            for (int i = 0; i < words.Length; i++) {
                words[i] = Reverse (words[i]);
            }
            return string.Join (" ", words);
        }

        public string Reverse (string s) {
            var chars = s.ToCharArray ();
            int i = 0;
            int j = chars.Length - 1;
            while (i < j) {
                Swap (ref chars, i, j);
                i++;
                j--;
            }
            return new String (chars);
        }

        public void Swap (ref char[] str, int i, int j) {
            var temp = str[i];
            str[i] = str[j];
            str[j] = temp;
        }

        public static void Main (string[] args) {
            WordReversalInString o = new WordReversalInString ();
            String s1 = "the sky is blue";
            String s2 = "Barkhs";
            Console.WriteLine (o.ReverseWords (s1));
            Console.WriteLine (o.Reverse (s2));
        }

    }
}