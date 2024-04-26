using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByArea.BST.m_230_KthSmallestElementInABST;

/*
https://leetcode.com/problems/kth-smallest-element-in-a-bst/description/

Given the root of a binary search tree, and an integer k, return the kth smallest value (1-indexed) of all the values of the nodes in the tree.

Example 1:

            3
           / \ 
          1   4
           \
            2

Input: root = [3,1,4,null,2], k = 1
Output: 1

Example 2:

Input: root = [5,3,6,2,4,null,null,1], k = 3
Output: 3

                            5
                           / \ 
                          3   6
                         / \
                        2   4                                  
                       /
                      1
 

Constraints:

The number of nodes in the tree is n.
1 <= k <= n <= 104
0 <= Node.val <= 104
 

Follow up: If the BST is modified often (i.e., we can do insert and delete operations) and you need to find the kth smallest frequently, how would you optimize?


I solved this tasl by myself!
Runtime 100 ms Beats 5.37% of users with C#
Memory 46.41 MB Beats 5.48% of users with C#

 */
internal class m_230_KthSmallestElementInBST
{
    public int KthSmallest(TreeNode root, int k)
    {
        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>(new Comparer());
        InOrderTraverse(root, priorityQueue);

        while (priorityQueue.Count > k) 
        {
            priorityQueue.Dequeue();
        }
        
        return priorityQueue.Peek();
    }

    private void InOrderTraverse(TreeNode root, PriorityQueue<int, int> priorityQueue)
    {
        if (root == null)
            return;

        if (root.left != null)
        {
            InOrderTraverse(root.left, priorityQueue);
        }

        priorityQueue.Enqueue(root.val, root.val);

        if (root.right != null)
        {
            InOrderTraverse(root.right, priorityQueue);
        }
    }

    class Comparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x==y)
                return 0;
            if ( x > y) 
                return -1;
            return
                1;
        }
    }
}

public class m_230_KthSmallestElementInABST_BootStrapper
{
    public void Run()
    {
        TreeNode tree_2 = new TreeNode { val = 2 };
        TreeNode tree_1 = new TreeNode { val = 1, right = tree_2 };

        TreeNode tree_4 = new TreeNode { val = 4 };
        TreeNode tree_3 = new TreeNode { val = 3, left = tree_1, right = tree_4 };

        int kthSmallest = new m_230_KthSmallestElementInBST().KthSmallest(tree_3, 1);
    }
}
