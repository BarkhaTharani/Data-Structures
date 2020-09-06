using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Data_Structures.Strings {
    public class StringAnagram {
        public static List<int> stringAnagram (List<string> dictionary, List<string> query) {

            Dictionary<string, int> resultList = new Dictionary<string, int> ();

            foreach(var item in dictionary) {                
                foreach (var qry in query) {
                    int count = 0;
                    var res = isAnagram (item, qry);
                    if (res) {
                        if (resultList.ContainsKey (qry)) {
                            resultList[qry] = resultList[qry]+1;
                        } else {
                            resultList.Add (qry, count+1);
                        }
                    } else {
                        if (!resultList.ContainsKey (qry))
                            resultList.Add (qry, 0);
                    }
                }
            }

            return resultList.Values.ToList ();
        }
        public static bool isAnagram (string str1, string str2) {
            int str1Length = str1.Length;
            int str2Length = str2.Length;

            if (str1Length != str2Length)
                return false;

            var str1Sorted = str1.ToCharArray ();
            var str2Sorted = str2.ToCharArray ();

            Array.Sort (str1Sorted);
            Array.Sort (str2Sorted);

            // Compare sorted strings 
            for (int i = 0; i < str1Length; i++) {
                if (str1Sorted[i] != str2Sorted[i]) {
                    return false;
                }
            }

            return true;
        }

        public static void Main () {
            // TextWriter textWriter = new StreamWriter ("E:\\barkha\\test.txt", true);

            // int dictionaryCount = Convert.ToInt32 (Console.ReadLine ().Trim ());

            List<string> dictionary = new List<string> () {
                "heater",
                "cold",
                "clod",
                "reheat",
                "docl",
            };

            // for (int i = 0; i < 5; i++) {
            //     string dictionaryItem = Console.ReadLine ();
            //     dictionary.Add (dictionaryItem);
            // }

            // int queryCount = Convert.ToInt32 (Console.ReadLine ().Trim ());

            List<string> query = new List<string> () {
                "codl",
                "heater",
                "abcd"
            };

            // for (int i = 0; i < queryCount; i++) {
            //     string queryItem = Console.ReadLine ();
            //     query.Add (queryItem);
            // }

            List<int> result = StringAnagram.stringAnagram (dictionary, query);

            Console.WriteLine (String.Join ("\n", result));

            // textWriter.Flush ();
            // textWriter.Close ();
        }
    }
}