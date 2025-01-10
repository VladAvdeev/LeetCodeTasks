using System.Security;

namespace PrefixSum
{
    public class PrefixSumSolution
    {
        public int LargestAltitude(int[] gain)
        {
            int altitude = 0;
            int maxAltitude = 0;
            foreach (int i in gain)
            {
                altitude += i;
                maxAltitude = Math.Max(maxAltitude, altitude);
            }
            return maxAltitude;
        }
        public int PivotIndex(int[] nums)
        {
            int totalSum = 0;
            int leftSum = 0;

            // сумма общая
            foreach(int i in nums)
            {
                totalSum += i;
            }


            // Проходим по массиву и вычисляем сумму слева
            for(int i =0; i < nums.Length;i++)
            {
                // правая сумма = общая сумма - левая сумма - текущий элемент
                int rightSum = totalSum - leftSum - nums[i];

                // Если левая сумма равна правой, возвращаем текущий индекс
                if (leftSum == rightSum)
                    return i;

                // обновляем левую сумма
                leftSum += nums[i];
            }
            return -1;
        }
       public int SubarraySum(int[] nums, int k)
       {
            // здесь ключ - накопленная сумма
            // значения - количество раз, которое каждая накопленная сумма встречалась
           Dictionary<int, int> prefixSum = new Dictionary<int, int>();
            prefixSum[0] = 1; // Для случаев, когда текущая сумма равна k

            int currentSum = 0;
            int count = 0;

            foreach(var num in nums)
            {
                currentSum += num;
                // Если ключ существует, значит, ранее уже была накопленная сумма, равная currentSum - k
                if (prefixSum.ContainsKey(currentSum - k))
                    //Это означает, что сумма элементов между этим местом и текущим индексом равна k.
                    count += prefixSum[currentSum - k];

                if (prefixSum.ContainsKey(currentSum))
                    prefixSum[currentSum]++;
                else
                    prefixSum[currentSum] = 1;
            }
            return count;
        }
    }
}
