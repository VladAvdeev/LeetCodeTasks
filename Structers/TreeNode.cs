using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks.Structers
{
    /// <summary>
    /// Структура узла
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
    public class BinaryTree<T>
    {
        public TreeNode<T> Root { get; private set; }
        public BinaryTree(T rootValue)
        {
            Root = new TreeNode<T>(rootValue);
        }
        public void Insert(T value)
        {
            Root = InsertRec(Root, value);
        }
        /// <summary>
        /// Вставка в бинарное дерево происходит путем выполнения сравнений и размещения нового узла в соответствующее место. 
        /// В примере используется бинарное дерево поиска, где левые потомки всегда меньше, а правые — больше родителя:
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns>Узел</returns>
        private TreeNode<T> InsertRec(TreeNode<T> node, T value)
        {
            if (node == null)
            {
                node = new TreeNode<T>(value);
                return node;
            }

            int comprison = Comparer<T>.Default.Compare(value, node.Value);
            if (comprison < 0)
            {
                node.Left = InsertRec(node.Left, value);
            }
            else if (comprison > 0)
            {
                node.Right = InsertRec(node.Right, value);
            }
            return node;
        }
        public bool Contains(T value)
        {
            return ContainsRec(Root, value);
        }
        /// <summary>
        /// Поиск элемента в бинарном дереве поиска также использует принцип сравнения и перехода к левому или правому потомку:
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool ContainsRec(TreeNode<T> node, T value)
        {
            if (node == null) return false;

            int comprison = Comparer<T>.Default.Compare(value, node.Value);
            if (comprison == 0) return true;

            return comprison < 0 ? ContainsRec(node.Left, value) : ContainsRec(node.Right, value);
        }
        public void Remove(T value)
        {
            Root = RemoveRec(Root, value);
        }
        /// <summary>
        /// Удаление узла из бинарного дерева поиска может быть сложной операцией, в зависимости от количества потомков у удаляемого узла:
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private TreeNode<T> RemoveRec(TreeNode<T> node, T value)
        {
            if (node == null) return node;

            int comparison = Comparer<T>.Default.Compare(value, node.Value);
            if (comparison < 0)
            {
                node.Left = RemoveRec(node.Left, value);
            }
            else if (comparison > 0)
            {
                node.Right = RemoveRec(node.Right, value);
            }
            else
            {
                // Узел с одним потомком или без потомков
                if (node.Left == null) return node.Right;
                else if (node.Right == null) return node.Left;

                // Узел с двумя потомками: получение наименьшего значения в правом поддереве
                node.Value = MinValue(node.Right);

                // Удаление наименьшего узла в правом поддереве
                node.Right = RemoveRec(node.Right, node.Value);
            }
            return node;
        }
        private T MinValue(TreeNode<T> node)
        {
            T minValue = node.Value;
            while (node.Left != null)
            {
                minValue = node.Left.Value;
                node = node.Left;
            }
            return minValue;
        }
        /// <summary>
        /// Обход дерева — это процесс посещения каждого узла дерева в определенном порядке. Существует несколько видов обхода: прямой (pre-order), центрированный (in-order), обратный (post-order) и по уровням (level-order).
        /// </summary>
        /// <param name="visit"></param>
        public void PreOrderTraversal(Action<T> visit)
        {
            PreOrderTraversalRec(Root, visit);
        }
        // // Прямой (pre-order) обход: корень -> левое поддерево -> правое поддерево
        private void PreOrderTraversalRec(TreeNode<T> node, Action<T> visit)
        {
            if (node != null)
            {
                visit(node.Value);
                PreOrderTraversalRec(node.Left, visit);
                PreOrderTraversalRec(node.Right, visit);
            }
        }
        // Центрированный (in-order) обход: левое поддерево -> корень -> правое поддерево
        public void InOrderTraversal(Action<T> visit)
        {
            InOrderTraversalRec(Root, visit);
        }
        private void InOrderTraversalRec(TreeNode<T> node, Action<T> visit)
        {
            if (node != null)
            {
                InOrderTraversalRec(node.Left, visit);
                visit(node.Value);
                InOrderTraversalRec(node.Right, visit);
            }
        }
        // Обратный (post-order) обход: левое поддерево -> правое поддерево -> корень
        public void PostOrderTraversal(Action<T> visit)
        {
            PostOrderTraversalRec(Root, visit);
        }
        private void PostOrderTraversalRec(TreeNode<T> node, Action<T> visit)
        {
            if (node != null)
            {
                PostOrderTraversalRec(node.Left, visit);
                PostOrderTraversalRec(node.Right, visit);
                visit(node.Value);
            }
        }
    }
}
