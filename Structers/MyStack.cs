using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks.Structers
{
    public class MyStack<T>
    {
        private T[] _items;
        private int _top;
        private const int DefaultCapacity = 10;

        public MyStack(int capacity = DefaultCapacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than zero");

            _items = new T[capacity];
            _top = -1;
        }

        /// <summary>
        /// Добавить элемент на вершину стека
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (_top == _items.Length - 1)
            {
                Resize();
            }
            _items[++_top] = item;
        }
        /// <summary>
        /// Удалить с элемент вершины стека
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            return _items[_top--];
        }
        /// <summary>
        /// Посмотреть элемент на верхушке без удаления
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            return _items[_top];
        }

        private void Resize()
        {
            Array.Resize(ref _items, _items.Length * 2);
        }
        public bool IsEmpty() => _top == -1;
        public int Size() => _top + 1;
    }
}
