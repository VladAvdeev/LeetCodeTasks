using System.Reflection;

namespace ArrayTasks
{
    public class ArraySol
    {
        public int RemoveElement(int[] nums, int val)
        {
            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[index++] = nums[i];
                }
            }
            return index;
        }
        // O(n)
        public int RemoveDuplicates(int[] nums)
        {
            int index = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[index])
                {
                    nums[++index] = nums[i];
                }
            }
            return index;
        }
        public int MajorityElement(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }
        public int RemoveDuplicatesII(int[] nums)
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
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            IList<bool> result = new List<bool>();
            var maxCandy = candies.Max();
            foreach (var candy in candies)
                result.Add(candy + extraCandies >= maxCandy);

            return result;
        }
        public IList<string> SummaryRanges(int[] nums)
        {
            List<string> numRanges = new List<string>();
            if (nums.Length == 0) return numRanges;
            
            int startRange = nums[0];
            
            for (int endRange = 1; endRange < nums.Length; endRange++)
            {
                // Если текущий элемент не является продолжением диапазона
                if (nums[endRange] != nums[endRange - 1] + 1)
                {
                    if (startRange == nums[endRange - 1])
                        numRanges.Add($"{startRange}");
                    else
                        numRanges.Add($"{startRange}->{nums[endRange - 1]}");

                    // Обновляем начало диапазона
                    startRange = nums[endRange];
                }
            }
            // Добавляем последний диапазон
            if (startRange == nums[^1])
                numRanges.Add($"{startRange}");
            else
                numRanges.Add($"{startRange}->{nums[^1]}");

            return numRanges;
        }
        public bool HasDuplicate(int[] nums)
        {
            HashSet<int> numSet = new HashSet<int>(nums);
            return numSet.Count != nums.Length;
        }
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] result = new int[nums.Length];
            // Заполняем массив произведениями всех элементов слева от текущего индекса
            result[0] = 1; // Слева от первого элемента ничего нет
            for (int i = 1;  i < nums.Length; i++)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }
            // Переменная для хранения произведения всех элементов справа
            int right = 1;
            for(int j = nums.Length - 1; j >= 0; j--)
            {
                // Умножаем текущее значение в result на произведение справа
                result[j] *= right;
                right *= nums[j];
            }
            return result;
        }
        public int HIndex(int[] citations)
        {
            Array.Sort(citations); // сортируем массив
            int n = citations.Length;

            for(int i = 0; i < n; i++)
            {
                int h = n - i; // количество статей с как минимум h цитированиям
                if (citations[i] >= h)
                    return h;
            }
            return 0;
        }
    }
}
