using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class MyQueue<T>
    {
        private T[] _items;
        private int _front; // Индекс первого элемента
        private int _back; // Индекс последнего элемента
        private int _size; // Количество элементов в очереди
        private const int DefaultCapacity = 10;
        Queue<int> queueInt = new Queue<int>();

        public MyQueue(int capacity = DefaultCapacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException("Capacity must be greater than zero");

            _items = new T[capacity];
            _front = 0;
            _back = -1;
            _size = 0;
        }
        /// <summary>
        /// Добавить элемент в очередь
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (_size == _items.Length)
                Resize();

            _back = (_back + 1) % _items.Length;
            _items[_back] = item;
            _size++;
        }
        /// <summary>
        /// Удалить элемент из очереди
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if(IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            T item = _items[_front];
            _front = (_front +1) % _items.Length;
            _size--;
            return item;
        }
        /// <summary>
        /// Посмотреть первый элемент очереди без удаления
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if(IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            return _items[_front];
        }

        public bool IsEmpty() => _size == 0;
        public int Size() => _size;
        // Увеличить размер внутреннего массива при переполнении
        private void Resize()
        {
            T[] newArray = new T[_items.Length * 2];
            for(int i = 0; i < _size; i++)
            {
                newArray[i] = _items[(_front + i) % _items.Length];
            }
            _items = newArray;
            _front = 0;
            _back = _size - 1;
        }
    }
}
