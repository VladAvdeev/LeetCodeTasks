using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class BacktrackingClass
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            Generate(result, "", n, n);
            return result;
        }

        private void Generate(List<string> result, string current, int open, int close)
        {
            // базовый случай: если длина строки равна 2n, то добавляем в результат
            if(open == 0 &&  close == 0)
            {
                result.Add(current);
                return;
            }
            // если можно добавить открывающуюся скобку
            if(open > 0)
            {
                Generate(result, current + "(", open - 1, close);
            }
            // если можно добавить закрывающуюся скобку
            if(close > open)
            {
                Generate(result, current + ")", open, close - 1);
            }
        }
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);

            var result = new List<IList<int>>();
            var combinations = new List<int>();

            // рекурсивный метод
            void Backtrack(int start, int remainingCombination)
            {
                // если оставшиеся комбинации = 0, то нашли все верно
                if(remainingCombination == 0)
                {
                    result.Add(new List<int>(combinations));
                    return;
                }
                // перебираем числа от 0 до  включительно
                for(int i =start; i < candidates.Length; i++)
                {
                    // если число больше оставшихся комбинаций, то пропускаем
                    if (candidates[i] > remainingCombination) break;
                    // добавляем текущее число в комбинацию
                    combinations.Add(candidates[i]);
                    // рекурсивый вызов для продолжения
                    Backtrack(i, remainingCombination - candidates[i]);
                    // убираем число и пробуем другие варианты
                    combinations.RemoveAt(combinations.Count-1);
                }
            }
            Backtrack(0, target);
            return result;
        }
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);

            var result = new List<IList<int>>();


            // рекурсивный метод
            void Backtrack(int start, int remainingCombination, List<int> combinations)
            {
                // если оставшиеся комбинации = 0, то нашли все верно
                if (remainingCombination == 0)
                {
                    result.Add(new List<int>(combinations));
                    return;
                }
                // перебираем числа от 0 до  включительно
                for (int i = start; i < candidates.Length; i++)
                {
                    // пропускаем дубликаты i > start означает, что это не первый элемент
                    if (i > start && candidates[i] == candidates[i - 1]) continue;

                    // то не имеет смысла идти дальше, так как 
                    if (candidates[i] > remainingCombination) break;

                    combinations.Add(candidates[i]);

                    Backtrack(i+1, remainingCombination - candidates[i], combinations);
                    // откат backtrack
                    combinations.RemoveAt(combinations.Count-1);
                }
            }
            Backtrack(0, target, new List<int>());
            return result;
        }
        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();

            void Backtrack(int start)
            {
                if (start == nums.Length)
                {
                    result.Add(new List<int>(nums));
                    return;
                }

                for(int i = start; i < nums.Length; i++)
                {
                    (nums[start], nums[i]) = (nums[i], nums[start]); // меняем местамиv
                    Backtrack(start + 1);
                    (nums[start], nums[i]) = (nums[i], nums[start]); // откатываем назад
                }
            }
            Backtrack(0);
            return result;
        }
    }
}
