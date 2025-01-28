using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class StackSolution
    {
        public bool IsValid(string s)
        {
            Stack<char> stackChar = new Stack<char>();
            Dictionary<char, char> mapping = new Dictionary<char, char>()
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };
            foreach (char c in s)
            {
                if (mapping.ContainsValue(c))
                    // Если символ — открывающая скобка, добавляем в стек
                    stackChar.Push(c);

                else if (mapping.ContainsKey(c))
                {
                    // Если символ — закрывающая скобка
                    if (stackChar.Count == 0 || stackChar.Pop() != mapping[c])
                        return false; // Либо стек пуст, либо скобки не совпадают
                }
                else
                    return false;
            }
            return stackChar.Count == 0;
        }
        public string SimplifyPath(string path)
        {
            // Разделяем путь на части по "/"
            string[] components = path.Split('/');
            Stack<string> pathStack = new Stack<string>();
            foreach (var component in components)
            {
                // Пропускаем пустые или текущие директории
                if (string.IsNullOrEmpty(component) || component == ".")
                {
                    continue;
                }
                else if (component == "..")
                {
                    // Возвращаемся к родительской директории, если стек не пуст
                    if (pathStack.Count > 0)
                        pathStack.Pop();
                }
                else
                    // Добавляем в стек имя директории
                    pathStack.Push(component);
            }
            // Собираем путь обратно из стека
            var result = new List<string>(pathStack);
            result.Reverse(); // Переворачиваем стек для правильного порядка
            return "/" + string.Join("/", result);
        }
    }
    public class MinStack
    {
        private Stack<int> stack; // Основной стек
        private Stack<int> minStack; // Стек для минимальных элементов

        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }
        public void Push(int val)
        {
            stack.Push(val);
            // Если minStack пуст или val <= текущему минимуму, добавляем его в minStack
            if (minStack.Count == 0 || val <= minStack.Peek())
            {
                minStack.Push(val);
            }
        }
        public void Pop()
        {
            // Если удаляемый элемент равен текущему минимуму, удаляем его из minStack
            if (stack.Peek() == minStack.Peek())
            {
                minStack.Pop();
            }
            stack.Pop();
        }
        public int Top()
        {
            return stack.Peek();
        }
        public int GetMin()
        {
            return minStack.Peek();
        }
    }
}
