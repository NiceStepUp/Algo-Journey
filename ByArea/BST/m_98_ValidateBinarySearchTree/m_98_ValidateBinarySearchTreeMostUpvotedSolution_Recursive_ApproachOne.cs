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

//
internal class m_98_ValidateBinarySearchTreeMostUpvotedSolution_Recursive_ApproachOne
{
    int prev = int.MinValue;

    public bool IsValidBSTByRecursion(TreeNode root)
    {
        if (root == null) return true;
        
        if (!IsValidBSTByRecursion(root.left))
        {
            return false;
        }

        if (prev >= root.val)
            return false;

        Console.WriteLine(@$"prev: {prev}" );
        Console.WriteLine($"root.val: {root.val}");
        Console.WriteLine("");

        prev = root.val;
        
        if (!IsValidBSTByRecursion(root.right))
        {
            return false;
        }

        return true;
    }
}

// https://leetcode.com/problems/validate-binary-search-tree/solutions/32104/c-in-order-traversal-and-please-do-not-rely-on-buggy-int-max-int-min-solutions-any-more/
internal class m_98_ValidateBinarySearchTreeMostUpvotedSolution_Recursive_ApproachTwo
{
    public bool IsValidBST(TreeNode root)
    {
        TreeNode prev = null;
        return Validate(root, prev);
    }

    public bool Validate(TreeNode node, TreeNode prev)
    {
        if (node == null) 
            return true;

        if (!Validate(node.left, prev)) 
            return false;

        if (prev != null && prev.val >= node.val) 
            return false;

        prev = node;
        return Validate(node.right, prev);
    }
}

public class m_98_ValidateBinarySearchTreeMostUpvotedSolution_Recursive_BootStrapper
{
    public void Run()
    {
        /*
        TreeNode tree_3 = new TreeNode { val = 3 };
        TreeNode tree_6 = new TreeNode { val = 6 };
        TreeNode tree_4 = new TreeNode { val = 4, left = tree_3, right = tree_6 };

        TreeNode tree_1 = new TreeNode { val = 1 };
        TreeNode tree_5 = new TreeNode { val = 5, left = tree_1, right = tree_4 };

        bool IsBst = new m_98_ValidateBinarySearchTreeMostUpvotedSolution_Iterative().IsValidBSTByRecursion(tree_5);
        */

        TreeNode tree_1 = new TreeNode { val = 1 };
        TreeNode tree_3 = new TreeNode { val = 3 };
        TreeNode tree_2 = new TreeNode { val = 2, left = tree_1, right = tree_3 };

        TreeNode tree_7 = new TreeNode { val = 7 };
        TreeNode tree_4 = new TreeNode { val = 4, left = tree_2, right = tree_7 };
       
        bool IsBst = new m_98_ValidateBinarySearchTreeMostUpvotedSolution_Recursive_ApproachTwo().IsValidBST(tree_4);
    }
}