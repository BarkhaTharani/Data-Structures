namespace Data_Structures.Strings {
    public class StringReversal {
        public void ReverseString (char[] s) {
            int i = 0;
            int j = s.Length - 1;
            while (i < j) {
                Swap (ref s, i, j);
                i++;
                j--;
            }
        }

        public void Swap (ref char[] str, int i, int j) {
            var temp = str[i];
            str[i] = str[j];
            str[j] = temp;
        }

    }
}