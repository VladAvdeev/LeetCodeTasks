using System.Collections;

namespace LinkedList
{
    public class LinkedListSolutions
    {
        public ListNode AddTwoNumber(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
                return null;

            // Вычисляем сумму текущих значений
            int sum = (l1?.val ?? 0) +(l2?.val ?? 0);

            // Создаем текущий узел с результатом суммы
            ListNode resultNode = new ListNode(sum % 10);

            // Определяем перенос для следующего узла
            int carry = sum / 10;

            // рекурсивный вызов для след узла
            resultNode.next = AddTwoNumber(l1?.next, l2?.next);

            // Если перенос есть, добавляем его в следующую позицию
            if(carry > 0)
            {
                resultNode.next = AddTwoNumber(resultNode.next, new ListNode(carry));
            }
            return resultNode;

        }
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return false;

            ListNode slow = head;
            ListNode fast = head.next;

            while(slow != fast)
            {
                if (fast == null || fast.next == null)
                    return false;

                slow = slow.next; // Двигается на 1 узел
                fast = fast.next.next; // Двигается на 2 узла
            }
            return true; // Если указатели встретились, есть цикл
        }
        public ListNode DeleteDuplicates(ListNode head)
        {
            // объявляем текущий узел
            var currentNode = head;

            // пока текущий узел и следующий узел не равный null
            while (currentNode != null && currentNode.next != null)
            {
                // если текущий узел равен следующему, то "удаляем" дубликат, пропуская этот узел
                if (currentNode.val == currentNode.next.val)
                {
                    // пропуск узла
                    currentNode.next = currentNode.next.next;
                }
                else
                {
                    // переход на следующий узел
                    currentNode = currentNode.next;
                }
            }
            return head;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class MyHashSet
    {
        private const int Size = 769; // Размер массива (простое число для уменьшения коллизий)
        private LinkedList<int>[] buckets; // Массив бакетов с цепочками
        public MyHashSet()
        {
            buckets = new LinkedList<int>[Size];
            for(int i = 0 ; i < Size; i++)
            {
                buckets[i] = new LinkedList<int>(); // Инициализируем каждый бакет
            }
        }
        private int GetBucketIndex(int key)
        {
            return key % Size;
        }
        public void Add(int key)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];

            if (!bucket.Contains(key))
            {
                bucket.AddLast(key);
            }
        }
        public void Remove(int key)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];

            if (bucket.Contains(key))
            {
                bucket.Remove(key);
            }
        }
        public bool Contains(int key)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];

            return bucket.Contains(key);
        }
    }
    public class MyHashSetBit
    {
        // массив битов, где каждый элемент представляет собой логическое значение (true или false)

        /*Внутренне BitArray использует минимальное количество памяти, 
         * так как каждый элемент занимает 1 бит */
        BitArray bitArray;
        public MyHashSetBit()
        {
            // Ключи, которые нужно хранить в HashSet, предполагаются от 0 до 1000000 (1 миллион ключей).
            // см. ограничения задачи
            bitArray = new BitArray(1000000 + 1);
        }
        public void Add(int key)
        {
            // Каждое значение ключа напрямую соответствует индексу в BitArray
            bitArray[key] = true;
            // key = 5 → bitArray[5] = true означает, что ключ 5 добавлен.
        }
        public void Remove(int key)
        {
            // bitArray[5] = false означает, что ключ 5 удален.
            bitArray[key] = false;
        }
        public bool Contains(int key)
        {
            return bitArray[key];
        }
    }
}
