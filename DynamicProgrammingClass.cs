using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class DynamicProgrammingSolution
    {
        public int MaxProfit(int[] prices)
        {
            int minProfit = prices[0];
            int maxProfit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < minProfit)
                {
                    minProfit = prices[i];
                }
                else if ((prices[i] - minProfit) > maxProfit)
                {
                    maxProfit = prices[i] - minProfit;
                }
            }
            return maxProfit;
        }
        public int MaxProfit2(int[] prices)
        {
            int maxProfit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }
            return maxProfit;
        }
        public int Rob(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return nums[0];

            int n = nums.Length;
            int[] dp = new int[n];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            }
            return dp[n - 1];
        }
        public int RobMemo(int[] nums)
        {
            // Массив для запоминания результатов
            Dictionary<int, int> memoRob = new Dictionary<int, int>();

            // Вспомогательный метод с мемоизацией
            int RobHelper(int index)
            {
                // Базовый случай: индекс вне массива
                if (index >= nums.Length)
                    return 0;

                // Если результат уже есть в мемо, вернуть его
                if (memoRob.ContainsKey(index))
                    return memoRob[index];

                // Вариант 1: Грабить текущий дом
                int robCurrent = nums[index] + RobHelper(index + 2);

                // Вариант 2: Пропустить текущий дом
                int skipCurrent = RobHelper(index + 1);

                // Запоминаем максимальный результат
                memoRob[index] = Math.Max(robCurrent, skipCurrent);

                return memoRob[index];
            }
            return RobHelper(0);
        }

    }
}
