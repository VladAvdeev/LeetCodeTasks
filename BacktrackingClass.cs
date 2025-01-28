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
    }
}
