namespace ByArea.BST.m_1008_ConstructBinarySearchTreeFromPreorderTraversal;

/*
 Given an array of integers preorder, which represents the preorder traversal of a BST (i.e., binary 
search tree), construct the tree and return its root.

It is guaranteed that there is always possible to find a binary search tree with the given 
requirements for the given test cases.

A binary search tree is a binary tree where for every node, any descendant of Node.left has a value 
strictly less than Node.val, and any descendant of Node.right has a value strictly 
greater than Node.val.

A preorder traversal of a binary tree displays the value of the node first, then 
traverses Node.left, then traverses Node.right. 

Example 1:

                        8
                      /   \
                    5      10
                   / \       \
                  1   7       12        

Input: preorder = [8,5,1,7,10,12]
Output: [8,5,10,1,7,null,12]
Example 2:

Input: preorder = [1,3]
Output: [1,null,3]

 */

/*
https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/solutions/252232/java-c-python-o-n-solution/

Runtime 65 ms Beats 26.92% of users with C#
Memory 40.56 MB Beats 50.00% of users with C#

 */
public class m_1008_ConstructBinarySearchTreeFromPreorderTraversal_Repetition
{
    int index = 0;

    public TreeNode BstFromPreorder(int[] preorder)
    {
        return ToBst(preorder, int.MaxValue);
    }

    private TreeNode ToBst(int[] numbers, int bound)
    {
        if (numbers.Length <= index
            || numbers[index] > bound)
            return null;

        TreeNode root = new() { val = numbers[index++] };
        root.left = ToBst(numbers, root.val);
        root.right = ToBst(numbers, bound);
        return root;
    }
}

public class m_1008_ConstructBinarySearchTreeFromPreorderTraversal_Repetition_Bootstrapper
{
    public TreeNode Run()
    {
        int[] numbers = [8, 5, 1, 7, 10, 12];
        TreeNode tree = new m_1008_ConstructBinarySearchTreeFromPreorderTraversal_Repetition
            ().BstFromPreorder(numbers);
        return tree;
    }
}


