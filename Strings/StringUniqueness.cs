using System.Collections.Generic;

namespace Data_Structures.Strings {
    public class StringUniqueness {

        public bool IsStringUnique (char[] str) {
            Dictionary<char, int> dict = new Dictionary<char, int> ();
            int count = 0;
            for (int i = 0; i < str.Length; i++) {

                if (!dict.ContainsKey (str[i])) {
                    dict.Add (str[i], count);
                    continue;
                }

                return false;
            }

            return true;
        }

        public bool ContainsDuplicate (int[] nums) {
            Dictionary<int, int> dict = new Dictionary<int, int> ();

            int count = 0;
            for (int i = 0; i < nums.Length; i++) {

                if (!dict.ContainsKey (nums[i])) {
                    dict.Add (nums[i], count);
                    continue;
                }

                return true;

            }

            return false;
        }


        //take too much time/ not optimal
        public bool HasDuplicate (int[] nums) {

            for (int i = 0; i < nums.Length; i++) {
                for (int j = i + 1; j < nums.Length; j++) {
                    if (nums[j] == nums[i])
                        return true;

                }

            }
            return false;
        }
    }
}