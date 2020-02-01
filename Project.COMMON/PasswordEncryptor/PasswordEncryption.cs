using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.PasswordEncryption
{
    public static class PasswordEncryption
    {
        private static char[] UpperLetter = { 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'I', 'İ', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z' };
        private static char[] LowerLetter = { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'ı', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z' };
        private static char Cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {
                return ch;
            }
            if (char.IsUpper(ch))
            {
                return UpperLetter[(Array.IndexOf(UpperLetter, ch) + key) % 29];
            }
            else
            {
                return LowerLetter[(Array.IndexOf(LowerLetter, ch) + key) % 29];
            }
        }
        public static string EncryptPassword(string input, int key)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char ch in input)
            {
                sb.Append(Cipher(ch, key));
            }
            return sb.ToString();
        }
        public static string DecryptPassword(string input, int key)
        {
            return EncryptPassword(input, 29 - key);
        }
    }
}
