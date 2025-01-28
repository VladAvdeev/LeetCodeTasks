using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class HashTableSolution
    {

        public bool WordPattern(string pattern, string s)
        {
            // строку делим на массив
            var splittedStr = s.Split(' ');
            // проверяем длину, если она не равна, то далее нет смысла проверять
            if (pattern.Length != s.Split(' ').Count())
                return false;

            // создаем два словаря, по ним будем проверять условия
            Dictionary<char, string> patternToWord = new Dictionary<char, string>();
            Dictionary<string, char> wordToPattern = new Dictionary<string, char>();


            for (int i = 0; i < splittedStr.Length; i++)
            {
                char charPattern = pattern[i];
                string word = splittedStr[i];
                // есть ли элемент в словаре
                if (patternToWord.ContainsKey(pattern[i]))
                {
                    //если есть, то проверяем совпадение по слову
                    if (patternToWord[charPattern] != word)
                        return false;

                }
                else
                {
                    // проверям содержит ли ключ
                    if (wordToPattern.ContainsKey(word))
                        return false;

                    // сюда просто записываем по очереди наши чары и строки
                    patternToWord[charPattern] = word;
                    wordToPattern[word] = charPattern;
                }
            }
            return true;
        }
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            Span<int> usedS = stackalloc int[26];
            Span<int> usedT = stackalloc int[26];

            for (int i = 0; i < s.Length; i++)
            {
                usedS[s[i] - 97]++;
                usedT[t[i] - 97]++;
            }
            return usedS.SequenceEqual(usedT);
        }
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> resultDict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int x = target - nums[i];
                if (resultDict.ContainsKey(x))
                {
                    return [resultDict[x], i];
                }
                resultDict[nums[i]] = i;
            }
            return [];
        }
        public bool IsHappy(int n)
        {
            var numbersSet = new HashSet<int>();
            while (n > 1 && numbersSet.Add(n))
            {
                var sum = 0;
                while (n > 0)
                {
                    sum += (n % 10) * (n % 10);
                    n /= 10;
                }
                n = sum;
            }
            return n == 1;
        }
        public int[] TwoSum2(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;

            while (left < right)
            {
                int result = numbers[left] + numbers[right];
                if (result == target)
                    return [++left, ++right];
                else if (result > target)
                    right--;
                else
                    left++;
            }
            return [];

        }
        public char FindTheDifference(string s, string t)
        {
            char result = '\0';

            foreach (char c in s)
            {
                result ^= c;
            }

            foreach (char c in t)
            {
                result ^= c;
            }
            return result;
        }
        public int LongestConsecutive(int[] nums)
        {

            if (nums.Length == 0) return 0;

            HashSet<int> numSet = new HashSet<int>(nums);
            int longestSequence = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                // Проверяем, является ли текущее число началом последовательности
                if (!numSet.Contains(nums[i] - 1))
                {
                    int currentNum = nums[i];
                    int currentSequence = 1;

                    // Проверяем длину текущей последовательности
                    while (numSet.Contains(currentNum + 1))
                    {
                        currentNum++;
                        currentSequence++;
                    }
                    longestSequence = Math.Max(longestSequence, currentSequence);
                }
                // Обновляем максимальную длину последовательности
            }
            return longestSequence;
        }
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            // Проверяем на пустой массив или отсутствие строк
            if (strs == null || strs.Length == 0)
                return new List<IList<string>>();


            // Создаем словарь, где ключ — отсортированная версия строки, значение — список анаграмм
            Dictionary<string, List<string>> groupAnagramsDict = new Dictionary<string, List<string>>();

            foreach (string str in strs)
            {
                // Создаем массив частот букв
                int[] charCounts = new int[26];
                foreach (char c in str)
                {
                    charCounts[c - 'a']++;
                }

                // Преобразуем частотный массив в строку (ключ)
                string key = string.Join("#", charCounts);

                // Добавляем строку в соответствующую группу
                if (!groupAnagramsDict.ContainsKey(key))
                    groupAnagramsDict[key] = new List<string>();

                groupAnagramsDict[key].Add(str);
            }
            // Преобразуем словарь в список списков
            return new List<IList<string>>(groupAnagramsDict.Values);
        }
        public IList<string> LetterCombinations(string digits)
        {

            var result = new List<string>();
            Dictionary<char, string> numberLetters = new Dictionary<char, string>()
        {
            {'1', ""},
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };
            if (digits.Length == 0 || String.IsNullOrEmpty(digits))
                return [];

            // рекурсивный метод для формирования комбинация
            void Backtrack(string combination, int index)
            {
                // если текущая комбинация равна длине digits, добавляем её в результат
                if (index == digits.Length)
                {
                    result.Add(combination);
                    return;
                }

                // получаем текущую цифру и набор букв, соответствующих ей
                char digit = digits[index];
                string letters = numberLetters[digit];

                // для каждой буквы добавляем её к текущей комбинации
                foreach (char letter in letters)
                {
                    Backtrack(combination + letter, index + 1);
                }
                // начинаем рекурсию с пустой комбинации и с нулевого индекса
            }
            Backtrack("", 0);
            return result;

        }


    }
}
