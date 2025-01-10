using System.Data;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Transactions;

namespace BinarySearchSolutions
{
    public class BinarySearchSolution
    {
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int middle = left + (right - left)/2;

                if (nums[middle] == target)
                {
                    return middle;
                }
                else if (nums[middle] > target)
                {
                    right = middle - 1;
                }
                else
                    left = middle + 1;
            }
            return left;
        }
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0)
                return [-1, -1];

            int leftIndex = BinarySearchRange(nums, target, true); // Ищем левую границу
            int rightIndex = BinarySearchRange(nums, target, false); // Ищем правую границу

            return new int[] { leftIndex, rightIndex }; 
        }
        private int BinarySearchRange(int[] nums, int target, bool findLeft)
        {
            int left = 0;
            int right = nums.Length - 1;
            int boundary = -1;  // Переменная для хранения границы (по умолчанию -1)

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if(nums[middle] == target)
                {
                    boundary = middle; // Запоминаем найденный индекс
                    if (findLeft)  // Если ищем левую границу
                    {
                        right = middle - 1; // Ищем дальше влево
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
                // Если текущий элемент меньше `target`
                else if (nums[middle] < target)
                {
                    left = middle + 1; // Сдвигаем левый указатель вправо
                }
                // Если текущий элемент больше `target`
                else
                {
                    right = middle - 1;  // Сдвигаем правый указатель влево
                }
            }
            return boundary;
        }
        public int MinSubArrayLen(int target, int[] nums)
        {
            int minSizeSum = 0;
            int left = 0;
            int minLength = int.MaxValue; // поскольку размер динамический, делаем размер макс возможным
            for(int right = 0; right < nums.Length; right++)
            {
                minSizeSum += nums[right]; // добавляем сумму элементов
                
                while(minSizeSum >= target)// здесь двигаем start
                {
                    minLength = Math.Min(minLength, right - left +1);
                    minSizeSum -= nums[left];
                    left++;
                }
            }
            return minLength== int.MaxValue ? 0 : minLength;
        }
        public int SearchInRotatedSortedArray(int[] nums, int target)
        {
            int left = 0; // Начальный указатель — левый конец массива
            int right = nums.Length - 1; // Конечный указатель — правый конец массива

            while (left <= right) // Выполняем поиск, пока есть элементы между указателями
            {
                int middle = left + (right - left) / 2; // Находим средний индекс для проверки
                int result = nums[middle]; // Получаем значение элемента в середине массива

                if (result == target) // Если значение в середине равно искомому числу
                    return middle;
                // Проверяем, находится ли середина в первой (отсортированной) половине
                else if (result >= nums[left])
                {
                    // Если цель лежит между левым указателем и серединой
                    if (nums[left] <= target && target < result)
                        right = middle - 1; // Смещаем правый указатель влево, исключая правую часть
                    else
                        left = middle + 1;// Иначе смещаем левый указатель вправо
                }
                // Если середина в правой (отсортированной) половине
                else if (result <= nums[right])
                {
                    // Если цель лежит между серединой и правым указателем
                    if (nums[right] >= target && target > result)
                        left = middle + 1;  // Смещаем левый указатель вправо, исключая левую часть
                    else
                        right = middle - 1; // Иначе сдвигаем правый указатель влево
                }
            }
            return -1;
        }
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int left = 0;
            int right = rows * cols - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                // Преобразуем одномерный индекс в двумерные координаты
                int row = middle / cols;
                int col = middle % cols;

                int current = matrix[row][col];

                if (current == target)
                    return true;

                else if (current > target)
                {
                    right = middle - 1;
                }
                else
                    left = middle + 1;
            }
            return false;
        }
        public bool SearchMatrixSortedDiagonal(int[][] matrix, int target)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            int row = 0;  // Начинаем с верхнего ряда
            int col = cols - 1;// И последнего столбцf

            while(row < rows && col >= 0)
            {
                int current = matrix[row][col];

                if (current == target)
                    return true;
                else if (current > target)
                    col--;// Переход вниз
                else
                    row++;
            }
            return false;
        }
        public int FindMin(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            
            while (left < right)
            {
                int middle = left + (right - left) / 2;

                // Если середина меньше последнего элемента, сужаем поиск слева
                if (nums[middle] < nums[right])
                    right = middle; // Минимум может быть middle
                // Если середина больше последнего элемента, сужаем поиск справа
                else
                    left = middle + 1; // Минимум находится справа
            }
            return nums[left]; // Минимум найден
        }
        public int GuessNumber(int n)
        {
            int left = 0;
            int right = n;

            while(left <= right)
            {
                int middle = left + (right - left) / 2;
                int guessNumber = Guess(middle);

                if (guessNumber == 0)
                    return middle;

                else if (guessNumber == 1)
                    left = middle + 1;

                else if(guessNumber == -1)
                    right = middle - 1;
            }
            return n;
        }
        private int Guess(int n) { return n; }

        public int FindPeakElement(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int middle = left + (right-left) / 2;

                bool isLeftPeak = middle == 0 || nums[middle] > nums[middle - 1];
                bool isRightPeak = middle == nums.Length - 1 || nums[middle] > nums[middle + 1];

                if (isLeftPeak && isRightPeak)
                    return middle;

                // пик может находиться справа, поэтому двигаем указатель вправо с помощью left
                else if (middle < nums.Length - 1 && nums[middle] < nums[middle + 1])
                {
                    left = middle + 1;
                }
                else
                    right = middle - 1;
            }
            throw new InvalidOperationException("No peak found");
        }
    }
}
