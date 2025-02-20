using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class QueueSolution
    {

    }
    public class RecentCounter
    {
        // объявляем очередь
        Queue<int> currentQueue;
        public RecentCounter()
        {
            // в конструкторе инициализируем очередь
            currentQueue = new Queue<int>();
        }
        public int Ping(int t)
        {
            // кладем в очередь элемент
            currentQueue.Enqueue(t);
            // по условию, если есть элементы старше t-3000, то должныя быть удалены
            while(currentQueue.Count > 0 && currentQueue.Peek() < t - 3000)
            {
                currentQueue.Dequeue();
                
            }
            return currentQueue.Count;
        }
    }
}
