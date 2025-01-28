using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class SortClass
    {
        public void BubbleSort(int[] nums)
        {
            int length = nums.Length;
            for (int i = 0; i < length - 1; i++) // Проход по массиву
            {
                for (int j = 0; j < nums.Length - i - 1; j++) // Сравниваем соседние элементы
                {
                    if (nums[j] > nums[j + 1]) // Сортировка по возрастанию
                    {
                        var temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }
        }
        public void SelectionSort(int[] nums)
        {
            int length = nums.Length;

            for (int i = 0; i < length - 1; i++)
            {
                var minIndex = i; // задаем i как минимальное число
                // Ищем минимальный элемент в неотсортированной части
                for (int j = i + 1; j < length; j++)
                {
                    if (nums[j] < nums[minIndex])
                    {
                        minIndex = j; // обновляем индекс минимального элемента
                    }
                }
                if (minIndex != i)
                {
                    var temp = nums[i];
                    nums[i] = nums[minIndex];
                    nums[minIndex] = temp;
                }
            }
        }
    }
}
