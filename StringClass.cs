using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class StringSolution
    {
        public int LengthOfLastWord(string s)
        {
            return s.Split(" ", StringSplitOptions.RemoveEmptyEntries).Last().Length;
        }
        public bool CanConstruct(string ransomNote, string magazine)
        {
            List<char> charList = new List<char>(magazine);

            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (!charList.Remove(ransomNote[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, char> mappingS = new Dictionary<char, char>();
            HashSet<char> mappedCharsT = new HashSet<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char charS = s[i];
                char charT = t[i];

                // Проверяем, есть ли сопоставление для charS
                if (mappingS.ContainsKey(charS))
                {
                    // Если уже есть сопоставление, оно должно совпадать с текущим символом из t
                    if (mappingS[charS] != charT)
                    {
                        return false;
                    }

                }
                else
                {
                    // Если сопоставления еще нет, проверяем, не использован ли уже charT
                    if (mappedCharsT.Contains(charT))
                    {
                        return false; // charT уже сопоставлен с другим символом
                    }
                    // Добавляем новое сопоставление
                    mappingS[charS] = charT;
                    mappedCharsT.Add(charT);
                }
            }
            return true;
        }
        public string GcdOfStrings(string str1, string str2)
        {
            // Проверяем, можно ли получить str1 и str2 путем повторения общего шаблона
            if ((str1 + str2) != (str2 + str1))
                return "";

            // находим НОД
            int gcdLength = Gcd(str1.Length, str2.Length);

            // Возвращаем префикс str1 длиной gcdLength
            return str1.Substring(0, gcdLength);
        }
        // Алгоритм Евклида для НОД
        private int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";

            string prefix = strs[0];

            for (int i = 1; i < strs.Length; i++)
            {
                while (!strs[i].StartsWith(prefix))
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (prefix == "") return "";
                }
            }
            return prefix;
        }
        public int RomanToIneger(string s)
        {
            int answer = 0;
            int num = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                switch (s[i])
                {
                    case 'I':
                        num = 1;
                        break;
                    case 'V':
                        num = 5;
                        break;
                    case 'X':
                        num = 10;
                        break;
                    case 'L':
                        num = 50;
                        break;
                    case 'C':
                        num = 100;
                        break;
                    case 'D':
                        num = 500;
                        break;
                    case 'M':
                        num = 1000;
                        break;
                }
                if (4 * num < answer)
                    answer -= num;
                else
                    answer += num;
            }
            return answer;
        }
        public string IntToRoman(int num)
        {
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder stringBuilder = new StringBuilder();

            // Идем по значениям от большего к меньшему
            for (int i = 0; i < values.Length && num > 0; i++)
            {
                // Пока число больше текущего значения, добавляем символ и вычитаем значение
                while (num >= values[i])
                {
                    stringBuilder.Append(symbols[i]);
                    num -= values[i];
                }
            }
            return stringBuilder.ToString();
        }
        public string Convert(string s, int numRows)
        {
            if (numRows == 1 || numRows >= s.Length)
                return s;

            // Создаем массив строк для хранения символов каждой строки зигзага
            List<string> rows = new List<string>(new string[numRows]);
            for (int i = 0; i < numRows; i++)
                rows[i] = "";

            int currentRow = 0;
            bool goingDown = false;

            // Проходим по всем символам строки
            foreach (char c in s)
            {
                rows[currentRow] += c;

                // Меняем направление при достижении верхней или нижней строки
                if (currentRow == 0 || currentRow == numRows - 1)
                    goingDown = !goingDown;

                currentRow += goingDown ? 1 : -1;
            }
            // Объединяем строки в одну
            return string.Join("", rows);
        }
    }
}
