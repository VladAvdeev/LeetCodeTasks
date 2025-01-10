namespace MathSolutions
{
    public class MathSolution
    {
        public int Reverse(int x)
        {
            int result = 0;
            while(x != 0)
            {
                int digit = x % 10;
                if(result > (Int32.MaxValue - digit)/10 || result < (Int32.MinValue - digit)/10)
                {
                    return 0;
                }
                result = result * 10 + digit;
                x /= 10;
            }
            return result;
        }
        public bool IsPalindrome(int x)
        {
            // Отрицательные числа или числа, оканчивающиеся на 0 (кроме 0), не палиндромы
            if (x < 0 || x %10 == 0 && x != 0)
                    return false;

            int reversed = 0;

            while(x > reversed)
            {
                // "Достаем" последнюю цифру числа и добавляем её к развернутому числу
                reversed = reversed * 10 + x % 10;
                x /= 10;  // Уменьшаем исходное число
            }
            // Число является палиндромом, если оно равно развернутой части
            // Или если развернутая часть равна числу без середины (в случае нечетного количества цифр)
            return x == reversed || x == reversed / 10;
        }
        public int[] PlusOne(int[] digits)
        {
            for(int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] == 9)
                    digits[i] = 0;

                else
                {
                    digits[i]++;
                    return digits;
                }
            }
            int[] firstOne = { 1 };
            return firstOne.Concat(digits).ToArray();
        }
    }
}
