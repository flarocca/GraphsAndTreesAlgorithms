using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAndTreesAlgorithms.Trees
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T> Right { get; }
        public BinaryTreeNode<T> Left { get; }

        public T Data { get; }
    }
}
