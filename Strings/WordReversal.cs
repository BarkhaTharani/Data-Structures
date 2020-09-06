using System;

namespace Data_Structures.Strings {
    public class WordReversal {
        public string ReverseWord (string s) {
            string[] words = s.Split (" ");

            int i = 0;
            int j = words.Length - 1;

            while (i < j) {
                string temp = words[j];
                words[j] = words[i];
                words[i] = temp;

                i++;
                j--;
            }
            return String.Join (" ", words);
        }

        public static void Main (string[] args) {
            WordReversal o = new WordReversal ();
            String s1 = "the sky is blue";
            Console.WriteLine (o.ReverseWord (s1));
        }
    }
}