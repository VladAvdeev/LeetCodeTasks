using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class IntervalSolution
    {
        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length <= 1)
                return intervals;

            // шаг 1: // Сортировка по началу интервалов
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            // CompareTo для сравнения двух объектов одного типа - помогает определить порядок элементов

            var result = new List<int[]>();
            var currentInterval = intervals[0];
            result.Add(currentInterval);

            // шаг 2: итерация по интервалам
            foreach (var interval in intervals)
            {
                int currentStart = currentInterval[0];
                int currentEnd = currentInterval[1];
                int nextStart = interval[0];
                int nextEnd = interval[1];

                if (currentEnd >= nextStart)
                {
                    // Пересекаются, обновляем конец текущего интервала
                    currentInterval[1] = Math.Max(currentEnd, nextEnd);
                }
                else
                {
                    // Не пересекаются, добавляем новый интервал
                    currentInterval = interval;
                    result.Add(currentInterval);
                }
            }
            return result.ToArray();
        }
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();
            int i = 0;

            // Добавить все интервалы, которые заканчиваются до начала newInterval
            while (i < intervals.Length && intervals[i][1] < newInterval[0])
            {
                result.Add(intervals[i]);
                i++;
            }
            // Слить перекрывающиеся интервалы
            while (i < intervals.Length && intervals[i][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }
            // Добавить объединённый интервал
            result.Add(newInterval);

            // добавление оставшихся интервалов
            while (i < intervals.Length)
            {
                result.Add(intervals[i]);
                i++;
            }
            return result.ToArray();
        }
        public int FindMinArrowShots(int[][] points)
        {
            // Сортируем интервалы по их конечным точкам (xend)
            Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));

            int arrowCount = 1; // первая стрела всегда нужна
            int lastArrowInterval = points[0][1]; // Выпустим первую стрелу в конец первого интервала

            foreach (var point in points)
            {
                int nextStart = point[0];
                int nextEnd = point[1];

                // Если интервал не пересекается с текущей стрелой, выпускаем новую
                if (nextStart > lastArrowInterval)
                {
                    arrowCount++;
                    lastArrowInterval = nextEnd; // Обновляем позицию стрелы
                }
            }
            return arrowCount;
        }
    }
}
