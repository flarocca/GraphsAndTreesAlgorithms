using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAndTreesAlgorithms.Trees
{
    public class Searcher<T>
    {
        public bool BreathFirst(T data, BinaryTreeNode<T> root)
        {
            var queue = new Queue<BinaryTreeNode<T>>();
            BinaryTreeNode<T> current;
            queue.Enqueue(root);

            while(queue.Count!= 0)
            {
                current = queue.Dequeue();
                if (current.Data.Equals(data))
                    return true;
                else
                {
                    queue.Enqueue(current.Left);
                    queue.Enqueue(current.Right);
                }
            }
            return false;
        }

        public bool TunnedBreathFirst(T data, BinaryTreeNode<T> root)
        {
            var enqueue = new Action<Queue<BinaryTreeNode<T>>, BinaryTreeNode<T>>((queue, d) => { queue.Enqueue(d); });
            var dequeue = new Func<Queue<BinaryTreeNode<T>>, BinaryTreeNode<T>>((queue) => { return queue.Dequeue(); });

            return Search(data, root, enqueue, dequeue);
        }

        public bool DepthFirst(T data, BinaryTreeNode<T> root)
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> current;
            stack.Push(root);

            while (stack.Count != 0)
            {
                current = stack.Pop();
                if (current.Data.Equals(data))
                    return true;
                else
                {
                    stack.Push(current.Left);
                    stack.Push(current.Right);
                }
            }
            return false;
        }

        public bool TunnedDepthFirst(T data, BinaryTreeNode<T> root)
        {
            var push = new Action<Stack<BinaryTreeNode<T>>, BinaryTreeNode<T>>((stack, d) => { stack.Push(d); });
            var pop = new Func<Stack<BinaryTreeNode<T>>, BinaryTreeNode<T>>((stack) => { return stack.Pop(); });

            return Search(data, root, push, pop);
        }

        private bool Search<Q>(T data, BinaryTreeNode<T> root, Action<Q, BinaryTreeNode<T>> add, Func<Q, BinaryTreeNode<T>> get) where Q: IEnumerable<BinaryTreeNode<T>>, new()
        {
            var container = new Q();
            BinaryTreeNode<T> current;
            add(container, root);

            while (container.Count() != 0)
            {
                current = get(container);
                if (current.Data.Equals(data))
                    return true;
                else
                {
                    add(container, current.Left);
                    add(container, current.Right);
                }
            }
            return false;
        }
    }
}
