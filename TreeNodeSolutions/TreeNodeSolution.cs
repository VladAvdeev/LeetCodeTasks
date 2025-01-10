namespace TreeNodeSolutions
{
    public class TreeNodeSolution
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            var leftDepth = MaxDepth(root.left);
            var rightDepth = MaxDepth(root.right);
            // добавляется + 1, чтобы учесть текущий узел дерева в подсчете глубины
            return Math.Max(leftDepth, rightDepth) + 1;
        }
        public int MaxDepthBFS(TreeNode root)
        {
            if (root == null) return 0;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int depth = 0;

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                for(int i = 0; i < levelSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();
                    if(currentNode.left != null) queue.Enqueue(currentNode.left);
                    if(currentNode.right != null) queue.Enqueue(currentNode.right);
                }
                depth++;
            }
            return depth;
        }
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if(p == null && q == null) return true; // когда перебрали все узлы
            if(p == null || q == null) return false; // если один узел null, а другой - нет, то false
            if(p.val != q.val) return false;

            return (IsSameTree(p.right, q.right) && IsSameTree(p.left, q.left));
        }
        public bool IsSameTreeBFS(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true; // когда перебрали все узлы
            if (p == null || q == null) return false; // если один узел null, а другой - нет, то false

            Queue<TreeNode> queueP = new Queue<TreeNode>();
            Queue<TreeNode> queueQ = new Queue<TreeNode>();
            
            queueP.Enqueue(p);
            queueQ.Enqueue(q);

            while (queueP.Count > 0 || queueQ.Count > 0)
            {
                TreeNode currentNodeP = queueP.Dequeue();
                TreeNode currentNodeQ = queueQ.Dequeue();

                if(currentNodeP == null && currentNodeQ == null) continue; // Оба узла null - пропускаем
                if (currentNodeP == null || currentNodeQ == null) return false; // Один null, другой нет
                if (currentNodeP.val != currentNodeQ.val) return false;

                // Добавляем потомков в очереди для дальнейшей проверки
                queueP.Enqueue(currentNodeP.left);
                queueP.Enqueue(currentNodeP.right);
                queueQ.Enqueue(currentNodeQ.left);
                queueQ.Enqueue(currentNodeQ.right);

            }
            return queueP.Count == queueQ.Count;
        }
        public TreeNode InvertTree(TreeNode root)
        {
            // Если дерево пустое, возвращаем null
            if (root == null)
                return null;

            // Меняем местами левое и правое поддеревья
            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;

            // Рекурсивно инвертируем левое и правое поддеревья
            InvertTree(root.left);
            InvertTree(root.right);

            // Возвращаем корень инвертированного дерева
            return root;
        }
        public TreeNode InvertTreeBFS(TreeNode root)
        {
            if (root == null)
                return null;

            Queue<TreeNode> treeNodes = new Queue<TreeNode>();
            treeNodes.Enqueue(root);// Добавляем корень в очередь

            while (treeNodes.Count > 0)
            {
                TreeNode current = treeNodes.Dequeue();
                // Меняем местами левое и правое поддеревья
                TreeNode temp = current.left;
                current.left = current.right;
                current.right = temp;

                if(current.left != null) treeNodes.Enqueue(current.left);
                if(current.right != null) treeNodes.Enqueue(current.right);

            }
            return root;

        }
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return IsMirror(root.left, root.right);
        }
        private bool IsMirror(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return true;
            if(t1 == null || t2 == null) return false;
            if(t1.val != t2.val) return false;

            return IsMirror(t1.left, t2.right) && IsMirror(t1.right, t2.left);
        }
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if(root == null) return false;
            if (root.left == null && root.right == null) return root.val == targetSum;

            return HasPathSum(root.left, targetSum - root.val) || HasPathSum(root.right, targetSum - root.val);
        }
        public int GetMinimumDifference(TreeNode root)
        {
            int minDifference = int.MaxValue; // Инициализируем минимальную разницу максимальным значением
            TreeNode prev = null; // Переменная для хранения предыдущего узла

            void InOrderTraversal(TreeNode node)
            {
                if (node == null) return;

                // Рекурсивно обходим левое поддерево
                InOrderTraversal(node.left);

                // Вычисляем разницу между текущим и предыдущим узлом
                if(prev != null)
                {
                    minDifference = Math.Min(minDifference, Math.Abs(node.val - prev.val));
                }
                prev = node; // Обновляем предыдущий узел

                // Рекурсивно обходим правое поддерево
                InOrderTraversal(node.right);
            }
            InOrderTraversal(root);
            return minDifference;
        }
        /// <summary>
        ///  В полном бинарном дереве каждый уровень, кроме последнего, полностью заполнен.
        ///  Последний уровень заполняется слева направо.
        ///  Для полного бинарного дерева можно вычислить высоту левого и правого поддеревьев:
        ///  Определяем размер полного поддерева на основе высоты и рекурсивно обрабатываем другое поддерево.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int CountNodes(TreeNode root)
        {
            if(root == null) return 0; // Если дерево пустое, то узлов нет

            int leftHeight = GetHeight(root.left);
            int rightHeight = GetHeight(root.right);

            if(leftHeight == rightHeight)
            {
                // Левое поддерево полностью заполнено
                // 2^leftHeight + узлы в правом поддереве
                return (1 << leftHeight) + CountNodes(root.right); // Все равно что Math.Pow(leftHeight, 0.5)
            }
            else
            {
                // Правое поддерево полностью заполнено
                // 2^rightHeight + узлы в левом поддереве
                return (1 << rightHeight) + CountNodes(root.left);
            }
        }
        private int GetHeight(TreeNode node)
        {
            int height = 0;
            while(node != null)
            {
                height++;
                node = node.left; // Двигаемся вниз по левым узлам
            }
            return height;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
