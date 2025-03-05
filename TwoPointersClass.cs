using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class TwoPointersSol
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            // последние элементы массивов
            int pointer1 = m - 1;
            int pointer2 = n - 1;

            // с конца проходим по массиву num1
            for (int i = nums1.Length - 1; i >= 0; i--)
            {
                // поинтеры будут понижаться и в моменте один из них может стать -1
                // это означает, что элементы закончились и мы прошлись по всем элементам
                if (pointer1 >= 0 && pointer2 >= 0)
                {
                    // начинаем с конца и сравниваем последние элементы двух массивов
                    // если с поинтера 1 больше, то в конце записываем это же число 
                    if (nums1[pointer1] > nums2[pointer2])
                    {
                        nums1[i] = nums1[pointer1];
                        pointer1--;
                    }
                    // иначе из numn2
                    else
                    {
                        nums1[i] = nums2[pointer2];
                        pointer2--;
                    }
                }
                // в моменте один из поинтеров станет меньше 0, нужно продолжать обработку оставшегося массива
                else if (pointer1 >= 0)
                {
                    nums1[i] = nums1[pointer1];
                    pointer1--;
                }
                else if (pointer2 >= 0)
                {
                    nums1[i] = nums2[pointer2];
                    pointer2--;
                }
            }
        }
        public int LengthOfLongestSubstring(string s)
        {
            int left = 0;
            int maxLength = 0;
            HashSet<char> charSet = new HashSet<char>();
            for (int right = 0; right < s.Length; right++)
            {
                while (charSet.Contains(s[right]))
                {
                    var leftChar = s[left];
                    charSet.Remove(leftChar);
                    left++;
                }
                charSet.Add(s[right]);

                maxLength = Math.Max(right - left + 1, maxLength);
            }
            return maxLength;
        }
        public bool IsSubSequence(string s, string t)
        {
            int leftCount = 0;
            int rightCount = 0;

            while (leftCount < s.Length && rightCount < t.Length)
            {
                if (s[leftCount] == t[rightCount])
                {
                    leftCount++;
                }
                rightCount++;
            }
            return leftCount == s.Length;
        }
        public bool IsPalindrome(string s)
        {
            var res = s.ToLower().Where(x => char.IsAsciiLetterOrDigit(x)).ToString();
            return res.Reverse().SequenceEqual(res);

        }
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            // Словарь для хранения последнего индекса каждого элемента
            Dictionary<int, int> hashSet = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                // Если элемент уже есть в словаре
                if (hashSet.ContainsKey(nums[i]))
                {
                    // Проверяем, удовлетворяет ли разница индексов условию
                    if (Math.Abs(i - hashSet[nums[i]]) <= k)
                        return true;
                }
                // Обновляем или добавляем текущий элемент в словарь
                hashSet[nums[i]] = i;
            }
            string s = "";
            // Если не найдено ни одной пары, возвращаем false
            return false;
        }
        public void MoveZeroes(int[] nums)
        {
            int lastZeroIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    (nums[lastZeroIndex], nums[i]) = (nums[i], nums[lastZeroIndex]);
                    lastZeroIndex++;
                }
            }
        }
        public int RemoveDuplicates2(int[] nums)
        {
            if (nums.Length <= 2)
                return nums.Length;

            int writeIndex = 2; // индекс, куда записываем элемент

            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] != nums[writeIndex - 2])
                {
                    nums[writeIndex] = nums[i];
                    writeIndex++;
                }
            }
            return writeIndex;

        }
        public void RotateArray(int[] nums, int k)
        {
            int n = nums.Length;
            k %= n; // Если k больше длины массива, берем остаток от деления

            // Шаг 1: Разворачиваем весь массив
            Reverse(nums, 0, n - 1);
            // Шаг 2: Разворачиваем первые k элементов
            Reverse(nums, 0, k - 1);
            // Шаг 3: Разворачиваем оставшиеся элементы
            Reverse(nums, k, n - 1);
        }
        private void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                var temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }
        public string MergeAlternately(string word1, string word2)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int maxLength = Math.Max(word1.Length, word2.Length);
            for (int i = 0; i < maxLength; i++)
            {
                if (i < word1.Length)
                {
                    stringBuilder.Append(word1[i]);
                }
                if (i < word2.Length)
                {
                    stringBuilder.Append(word2[i]);
                }
            }
            return stringBuilder.ToString();
        }
        public string ReverseWords(string s)
        {
            var stringArray = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int start = 0;
            int end = stringArray.Length - 1;

            while (start < end)
            {
                var temp = stringArray[start];
                stringArray[start] = stringArray[end];
                stringArray[end] = temp;
                start++;
                end--;
            }
            return String.Join(" ", stringArray);
        }
        public string LongestPalindromeSubstring(string s)
        {

            if (string.IsNullOrEmpty(s)) return "";

            int start = 0;
            int maxLength = 0;

            for (int i = 0; i < s.Length; i++)
            {
                // Расширение от центра (для нечетного палиндрома)
                int length1 = ExpandFromCenter(s, i, i);
                // Расширение от центра (для четного палиндрома)
                int length2 = ExpandFromCenter(s, i, i + 1);

                int lengthCompare = Math.Max(length1, length2);

                if (lengthCompare > maxLength)
                {
                    maxLength = lengthCompare;
                    start = i - (lengthCompare - 1) / 2; // Начальный индекс палиндрома
                }
            }
            return s.Substring(start, maxLength);
        }
        private int ExpandFromCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;// Длина палиндрома 
        }
        // переместить только гласные
        public string ReverseVowels(string s)
        {
            string vowels = "aeiouAEIOU";
            var charArray = s.ToCharArray();
            int start = 0;
            int end = s.Length - 1;
            while (start < end)
            {
                if (vowels.Contains(charArray[start]) && vowels.Contains(charArray[end]))
                {
                    var temp = charArray[start];
                    charArray[start] = charArray[end];
                    charArray[end] = temp;
                    start++;
                    end--;
                }
                // Если только левый символ не гласный, двигаем указатель вправо
                else if (!vowels.Contains(charArray[start]))
                {
                    start++;
                }
                // Если только правый символ не гласный, двигаем указатель влево
                else if (!vowels.Contains(charArray[end]))
                {
                    end--;
                }
            }
            return new string(charArray);
        }
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();

            // отсчет ведем до 3 элемента с конца
            for (int i = 0; i < nums.Length - 2; i++)
            {
                // Пропускаем дубли для первого элемента
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    // i!= left; left != right; right != i;
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });

                        // Пропускаем дубли для второго и третьего элементов
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        // Сдвигаем указатели
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                        left++;// Увеличиваем левый указатель, чтобы увеличить сумму
                    else
                        right--;// Уменьшаем правый указатель, чтобы уменьшить сумму
                }
            }
            return result;
        }
        public bool IsPalindromePointers(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;

            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                while (left < right && !Char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                while (left < right && !Char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
                if (Char.ToLower(s[left]) != Char.ToLower(s[right])) return false;

                left++;
                right--;
            }
            return true;
        }
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int closestSum = nums[0] + nums[1] + nums[2]; // инициализируем ближайшую сумму
            for (int i = 0; i < nums.Length - 2; i++) // до 3-х элементов с конца 
            {
                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int currentSum = nums[i] + nums[left] + nums[right]; // текущая сумма 

                    if (currentSum == target)
                    {
                        return currentSum;
                    }
                    // Обновляем ближайшую сумму, если текущая ближе к target
                    if ((Math.Abs(target - currentSum)) < Math.Abs(target - closestSum))
                    {
                        closestSum = currentSum;
                    }

                    if (currentSum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
            return closestSum;
        }
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();


            // отсчет до 4 элемента с конца? i фиксирует первый элемент
            for (int i = 0; i < nums.Length - 3; i++)
            {
                // пропускаем дубликаты для i
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                // j фиксирует второй элемент
                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    // пропускаем дубликаты для j
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;

                    int left = j + 1;
                    int right = nums.Length - 1;


                    while (left < right)
                    {
                        long sum = (long)nums[i] + nums[j] + nums[left] + nums[right];

                        if (sum == target)
                        {
                            // Добавляем текущую комбинацию в результат
                            result.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });

                            // пропускаем дубликаты для left и right
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;

                            // сдвигаем указатели
                            left++;
                            right--;
                        }
                        else if (sum < target)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }
            }
            return result;
        }
        public void NextPermutation(int[] nums)
        {
           int n = nums.Length;
            int i = n - 2;

            // находим первую пару, где n[i] < n[i+1] (двигаясь справа налево)
            while(i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            // Если нашли такой индекс
            if (i >= 0)
            {
                int j = n - 1;

            // 2. Найти самый маленький элемент справа, который больше nums[i]
                while (nums[j] <= nums[i])
                {
                    j--;
                }
                // поменять местами nums[i] и nums[j]
                (nums[i], nums[j]) = (nums[j], nums[i]);

            }
            // 4. Развернуть элементы после i, чтобы получить минимальную перестановку
            ReversePermutation(nums, i + 1, n - 1);
        }
        private void ReversePermutation(int[] nums, int left, int right)
        {
            while(left < right)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }
        }
    }
}
