using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class BitManipulationSolution
    {
        // сложение будет происходить бит за битом
        public string AddBinary(string a, string b)
        {
            int carry = 0; // переменная для переноса
            int i = a.Length - 1; // указатель на последний символ строки a
            int j = b.Length - 1; // указатель на последний символ строки b
            var result = new StringBuilder();

            while (i >= 0 || j >= 0 || carry > 0)
            {
                int sum = carry; // начинаем с переноса 

                // Добавляем биты из строки a, если они есть
                if (i >= 0)
                {
                    sum += a[i--] - '0';
                }
                // Добавляем биты из строки b, если они есть
                if (j >= 0)
                {
                    sum += b[j--] - '0';
                }
                // Добавляем текущий бит результата (остаток от деления на 2)
                result.Append(sum % 2);

                // Обновляем перенос (целая часть от деления на 2)
                carry = sum / 2;
            }
            // Переворачиваем строку результата, так как складывали с конца
            return new string(result.ToString().Reverse().ToArray());
        }
        public uint ReverseBits(uint n)
        {
            uint result = 0;
            for (int i = 0; i < 32; i++)
            {
                result = (result << 1) | (n & 1);
                n >>= 1;
            }
            return result;
        }
        /// <summary>
        /// алгоритм Брайана Кернигана
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeight(int n)
        {
            int count = 0;
            while (n != 0)
            {
                n &= (n - 1); // Обнуляем младший установленный бит
                count++;
            }
            return count;
        }
    }
}
