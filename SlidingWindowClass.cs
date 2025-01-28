using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class SlidingWindowSolution
    {
        public double FindMaxAverage(int[] nums, int k)
        {
            // инициализация окна
            double maxSum = 0;
            for (int i = 0; i < k; i++)
            {
                maxSum += nums[i];
            }

            double currentSum = maxSum;

            // сдвиг окна
            for (int i = k; i < nums.Length; i++)
            {
                currentSum += nums[i] - nums[i - k];
                maxSum = Math.Max(maxSum, currentSum);
            }
            // Возвращаем максимальное среднее значение
            return maxSum / k;
        }
        public int MaxVowels(string s, int k)
        {
            string vowels = "aeiou";

            int maxVowels = 0;

            // Инициализация: подсчитываем количество гласных в первом окне длиной k
            for (int i = 0; i < k; i++)
            {
                if (vowels.Contains(s[i]))
                {
                    maxVowels++;
                }
            }

            int currentVowels = maxVowels;

            // Сканируем строку, перемещая окно длиной k
            for (int i = k; i < s.Length; i++)
            {
                // Увеличиваем счетчик, если новый символ - гласный
                if (vowels.Contains(s[i]))
                {
                    currentVowels++;
                }
                // Уменьшаем счетчик, если символ, который выходит из окна, - гласный
                if (vowels.Contains(s[i - k]))
                {
                    currentVowels--;
                }
                maxVowels = Math.Max(maxVowels, currentVowels);
            }
            return maxVowels;
        }
        public IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();

            if (words == null || words.Length == 0 || s.Length == 0)
                return result;

            // инициализируем окно
            int wordLength = words[0].Length;
            int totalLength = wordLength * words.Length;

            // словарь для подсчеты частоты слов в массиве words
            Dictionary<string, int> wordCountDict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                // если не встречается слово в словаре, то количество 0
                if (!wordCountDict.ContainsKey(word))
                    wordCountDict[word] = 0;

                // тут мы заполняем словарь с количеством встречаемых слов
                wordCountDict[word]++;
            }

            // Проходим по всем возможным начальным позициям окна
            for (int i = 0; i < wordLength; i++)
            {
                int start = i, end = i;

                Dictionary<string, int> seenWordsDict = new Dictionary<string, int>();

                while (end + wordLength <= s.Length)
                {
                    // извлекаем слово из строки
                    string word = s.Substring(end, wordLength);
                    end += wordLength;

                    // Проверяем, содержится ли слово в words

                    if (wordCountDict.ContainsKey(word))
                    {
                        if (!seenWordsDict.ContainsKey(word))
                            seenWordsDict[word] = 0;

                        seenWordsDict[word]++;

                        // если слово встречается чаще чем нужно
                        while (seenWordsDict[word] > wordCountDict[word])
                        {
                            string removedWord = s.Substring(start, wordLength);
                            seenWordsDict[removedWord]--;

                            if (seenWordsDict[removedWord] == 0)
                                seenWordsDict.Remove(removedWord);

                            start += wordLength;
                        }
                        // если все слова совпадают
                        if (end - start == totalLength)
                            result.Add(start);
                    }
                    else
                    {
                        seenWordsDict.Clear();
                        start = end;
                    }
                }
            }
            return result;
        }
        public int FindMaxSumSubarray(int[] nums, int k)
        {
            // инициализируем окно
            int sum = 0;
            for (int i = 0; i < k; i++)
            {
                sum += nums[i];
            }

            int currentSum = sum;

            // сдвиг окна 
            for (int i = k; i < nums.Length; i++)
            {
                // nums[i] - добавляет новый элемент в окно
                currentSum += nums[i] - nums[i - k]; // nums[i - k] - таким образом убираем элемент выходящий за пределы окна 
                sum = Math.Max(sum, currentSum);
            }
            return sum;
        }
        public int CharacterReplacement(string s, int k)
        {
            int left = 0;
            int maxSeen = 0; // максимальная частота символа в текущем окне
            int maxLength = 0;

            Dictionary<char, int> seenChars = new Dictionary<char, int>();

            for (int right = 0; right < s.Length; right++)
            {
                // Увеличиваем частоту символа
                if (!seenChars.ContainsKey(s[right]))
                {
                    seenChars[s[right]] = 0;
                }
                seenChars[s[right]]++;

                // Обновляем максимальную частоту символа в окне
                maxSeen = Math.Max(maxSeen, seenChars[s[right]]);

                // проверяем нужно ли сжать окно
                while ((right - left + 1) - maxSeen > k) // Это количество замен, необходимых для приведения всех символов в окне к одному виду
                {
                    seenChars[s[left]]--;
                    left++; //  Если количество замен превышает k, двигаем левый указатель вправо, уменьшая окно.
                }
                // обновляем максимальную длину
                maxLength = Math.Max(maxLength, right - left + 1); // На каждом шаге обновляем максимальную длину окна, если текущее окно допустимо.
            }
            return maxLength;
        }
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                return false;

            int[] freq = new int[26];
            int[] freqWindow = new int[26];

            // полностью заполняем частотный массив s1
            foreach (var c in s1)
            {
                freq[c - 'a']++;
            }
            // заполняем окно первыми s1.Length символами s2
            for (int i = 0; i < s1.Length; i++)
            {
                freqWindow[s2[i] - 'a']++;
            }

            if (AreEqual(freq, freqWindow))
                return true;

            // сдвиг окна
            for (int i = s1.Length; i < s2.Length; i++)
            {
                // добавить новый сивол в окно
                freqWindow[s2[i] - 'a']++;

                // удалить старый символ
                freqWindow[s2[i - s1.Length] - 'a']--;

                if (AreEqual(freq, freqWindow)) return true;
            }
            return false;

        }
        private bool AreEqual(int[] freq1, int[] freq2)
        {
            for (int i = 0; i < 26; i++)
            {
                if (freq1[i] != freq2[i])
                    return false;
            }
            return true;
        }
        //public int[] MaxSlidingWindow(int[] nums, int k)
        //{
        //    Queue<int> queue = new Queue<int>();
        //    // инициализируем окно
        //    for(int i = 0; i < k; i++)
        //    {
        //        queue.Enqueue(nums[i]);
        //    }

        //    for(int i = 0; i < nums.Length; i++)
        //    {
        //        queue.Enqueue(nums[i]);
        //    }
        //}
    }
}
