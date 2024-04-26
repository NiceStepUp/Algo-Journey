using ByArea.BST.m_701_InsertIntoABinarySearchTree;

namespace ByArea.BST.m_98_ValidateBinarySearchTree;

/*
 98. Validate Binary Search Tree
Medium
Topics
Companies
Given the root of a binary tree, determine if it is a valid binary search tree (BST).

A valid BST is defined as follows:

The left 
subtree
 of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.
 

Example 1:

     2 
    / \
   1   3
Input: root = [2,1,3]
Output: true



Example 2:

                    5
                   / \
                  1   4
                     / \
                    3   8

Input: root = [5,1,4,null,null,3,6]
Output: false
Explanation: The root node's value is 5 but its right child's value is 4.
 

Constraints:

The number of nodes in the tree is in the range [1, 104].
-231 <= Node.val <= 231 - 1

 */

internal class m_98_ValidateBinarySearchTree
{
    private int previousValue;

    public bool IsValidBST(TreeNode root)
    {
        List<int> numbers = new ();
        TraverseTreeByInOrder(root, numbers);

        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i-1] >= numbers[i])
                return false;
        }

        return true;
    }

    private bool TraverseTreeByInOrder(TreeNode root, List<int> numbers)
    {
        if (root == null) 
            return true;

        // numbers.Add(root.val);   

        if (root.right != null) 
        {
            if (!TraverseTreeByInOrder(root.right, numbers))
                return false;

        }

        if (root.left != null)
        {
            if (!TraverseTreeByInOrder(root.left, numbers))
                return false;
        }

        
        previousValue = root.val;

        if (previousValue < root.val)
            return false;

        return true;
    }
}

public class m_98_ValidateBinarySearchTree_BootStrapper
{
    public void Run()
    {
        TreeNode tree_3 = new TreeNode { val = 3 };
        TreeNode tree_6 = new TreeNode { val = 6 };
        TreeNode tree_4 = new TreeNode { val = 4, left = tree_3, right = tree_6 };

        TreeNode tree_1 = new TreeNode { val = 1 };
        TreeNode tree_5 = new TreeNode { val = 5, left = tree_1, right = tree_4 };

        bool IsBst = new m_98_ValidateBinarySearchTree().IsValidBST(tree_5);
    }
}