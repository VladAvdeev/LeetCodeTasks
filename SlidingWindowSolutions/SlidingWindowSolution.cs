namespace SlidingWindowSolutions
{
    public class SlidingWindowSolution
    {
        public double FindMaxAverage(int[] nums, int k)
        {
            // инициализация окна
            double maxSum = 0;
            for(int i = 0; i < k; i++)
            {
                maxSum += nums[i];
            }

            double currentSum = maxSum;

            // сдвиг окна
            for(int i = k; i < nums.Length; i++)
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
            for (int i = 0;i < k; i++)
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
            
            if(words == null || words.Length == 0 || s.Length == 0)
                return result;

            // инициализируем окно
            int wordLength = words[0].Length;
            int totalLength = wordLength * words.Length;

            // словарь для подсчеты частоты слов в массиве words
            Dictionary<string, int> wordCountDict = new Dictionary<string, int>();

            foreach(var word in words)
            {
                // если не встречается слово в словаре, то количество 0
                if (!wordCountDict.ContainsKey(word))
                    wordCountDict[word] = 0;

                // тут мы заполняем словарь с количеством встречаемых слов
                wordCountDict[word]++;
            }

            // Проходим по всем возможным начальным позициям окна
            for(int i = 0; i < wordLength; i++)
            {
                int start = i, end = i;

                Dictionary<string, int> seenWordsDict = new Dictionary<string, int>();

                while(end + wordLength <= s.Length)
                {
                    // извлекаем слово из строки
                    string word = s.Substring(end, wordLength);
                    end += wordLength;

                    // Проверяем, содержится ли слово в words

                    if (wordCountDict.ContainsKey(word))
                    {
                        if(!seenWordsDict.ContainsKey(word))
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
    }
}
