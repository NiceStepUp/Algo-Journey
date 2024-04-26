namespace ByArea.BST.h_1569_NumberOfWaysToReorderArrayToGetSameBSTh;

/*
https://leetcode.com/problems/maximum-sum-bst-in-binary-tree/description/

Given a binary tree root, return the maximum sum of all keys of any sub-tree which is also a Binary Search Tree (BST).

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.
 

Example 1:

                                  1
                                 / \
                               4    3
                              / \   / \
                             2   4  2  5
                                      / \
                                     4   6
 Maximum sub tree is 3, 2, 5, 4, 6


Input: root = [1,4,3,2,4,2,5,null,null,null,null,null,null,4,6]
Output: 20
Explanation: Maximum sum in a valid Binary search tree is obtained in root node with key equal to 3.


Example 2:

            4
           /
          3
         / \
        1   2

Input: root = [4,3,null,1,2]
Output: 2
Explanation: Maximum sum in a valid Binary search tree is obtained in a single root node with key equal to 2.



Example 3:

Input: root = [-4,-2,-5]
Output: 0
Explanation: All values are negatives. Return an empty BST.
 

Constraints:

The number of nodes in the tree is in the range [1, 4 * 104].
-4 * 104 <= Node.val <= 4 * 10 the third power of 4
 */

internal class h_1373_MaximumSumBSTInBinaryTree
{
    private int _maxSum = 0;

    public int MaxSumBST(TreeNode root)
    {
        PostOrderTraverse(root);
        return _maxSum;
    }
    private int[] PostOrderTraverse(TreeNode root)
    {
        if (root == null) 
            return new int[] { int.MaxValue, int.MinValue, 0 }; // {min, max, sum}, initialize min=MAX_VALUE, max=MIN_VALUE

        int[] left = PostOrderTraverse(root.left);
        int[] right = PostOrderTraverse(root.right);

        // The BST is the tree:
        if (!(left != null             // the left subtree must be BST
                && right != null            // the right subtree must be BST
                && root.val > left[1]       // the root's key must greater than maximum keys of the left subtree
                && root.val < right[0]))    // the root's key must lower than minimum keys of the right subtree
            return null;

        int sum = root.val + left[2] + right[2]; // now it's a BST make `root` as root
        _maxSum = Math.Max(_maxSum, sum);
        int min = Math.Min(root.val, left[0]);
        int max = Math.Max(root.val, right[1]);
        return new int[] { min, max, sum };
    }
}


public class h_1373_MaximumSumBSTInBinaryTreeBootstrap
{
    public void Run() 
    {
        
        TreeNode tree_2 = new TreeNode() { val = 2 };
        TreeNode tree_4 = new TreeNode() { val = 4 };
        TreeNode tree_4_1 = new TreeNode() { val = 4, left = tree_2, right = tree_4 };

        TreeNode tree_6 = new TreeNode() { val = 6 };
        TreeNode tree_4_2 = new TreeNode() { val = 4 };
        TreeNode tree_5 = new TreeNode() { val = 5, left = tree_4_2, right = tree_6 };

        TreeNode tree_2_1 = new TreeNode() { val = 2 };
        TreeNode tree_3 = new TreeNode() { val = 3, left = tree_2_1, right = tree_5 };

        TreeNode tree_1 = new TreeNode() { val = 1, left = tree_4_1, right = tree_3 };

        h_1373_MaximumSumBSTInBinaryTree numberOfWaysToReorderArrayToGetSameBSTh = new();
        int result = numberOfWaysToReorderArrayToGetSameBSTh.MaxSumBST(tree_1);
        Console.WriteLine(result);
    }
}