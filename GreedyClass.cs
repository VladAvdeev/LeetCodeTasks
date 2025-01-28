using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class GreedySolution
    {

        public int MaxArea(int[] height)
        {
            int maxHeight = 0;
            int left = 0;
            int right = height.Length - 1;

            while (left < right)
            {
                // площадь контейнера
                int width = right - left; // расстояние между указателями
                // текущий объем воды
                int currentHeight = Math.Min(height[right], height[left]) * width;
                maxHeight = Math.Max(maxHeight, currentHeight); // обновляем максимум
                // Двигаем указатель с меньшей высотой
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return maxHeight;
        }
        public bool CanJump(int[] nums)
        {

            int achiveableIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                // Если текущий индекс недостижим, возвращаем false
                if (i > achiveableIndex)
                    return false;

                achiveableIndex = Math.Max(achiveableIndex, i + nums[i]);

                // Если уже можно добраться до конца, возвращаем true
                if (achiveableIndex >= nums.Length - 1)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// На каждой заправке у вас есть gas[i] единиц топлива, но нужно потратить cost[i] единиц, чтобы доехать до следующей станции.
        /// Если на каком-то этапе топлива недостаточно, значит, старт с текущей станции не приведет к успеху.
        /// </summary>
        /// <param name="gas"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int stationIndex = 0;
            int totalFuel = 0;
            int currentFuel = 0;

            for (int i = 0; i < gas.Length; i++)
            {
                totalFuel += gas[i] - cost[i];
                currentFuel += gas[i] - cost[i];

                // Если баланс стал отрицательным, начинаем с новой станции
                if (currentFuel < 0)
                {
                    stationIndex = i + 1;
                    currentFuel = 0; // Сбрасываем текущий баланс
                }
            }
            // Если общий баланс отрицательный, вернем -1
            return totalFuel >= 0 ? stationIndex : -1;
        }
        public int Jump2(int[] nums)
        {
            int countJump = 0; // Количество прыжков
            int longestJump = 0;  // Самый дальний индекс, который можно достичь
            int currentEnd = 0; // Текущий конец прыжка

            for (int i = 0; i <= nums.Length - 1; i++) // Обходим до предпоследнего элемента
            {
                longestJump = Math.Max(longestJump, i + nums[i]);

                if (i == currentEnd)
                {
                    countJump++;
                    currentEnd = longestJump;
                    // Если текущий конец достигает или превышает последний индекс, завершаем
                    if (currentEnd >= nums.Length - 1)
                        break;
                }

            }
            return countJump;
        }
    }
}
