using ByArea.BST.RangeSumOfBst_938_e;

namespace ByArea.BST.m_701_InsertIntoABinarySearchTree;

/*
https://leetcode.com/problems/insert-into-a-binary-search-tree/description/

You are given the root node of a binary search tree (BST) and a value to insert into the tree. Return the root node of the BST after the insertion. It is guaranteed that the new value does not exist in the original BST.

Notice that there may exist multiple valid ways for the insertion, as long as the tree remains a BST after insertion. You can return any of them.

 

Example 1:


Input: root = [4,2,7,1,3], val = 5
Output: [4,2,7,1,3,5]
Explanation: Another accepted tree is:

                        4
                      /   \
                    2      7
                   / \       
                  1   3      


                        4
                      /   \
                    2      7
                   / \    /     
                  1   3  5    


Example 2:

Input: root = [40,20,60,10,30,50,70], val = 25
Output: [40,20,60,10,30,50,70,null,null,25]
Example 3:

Input: root = [4,2,7,1,3,null,null,null,null,null,null], val = 5
Output: [4,2,7,1,3,5]
 

Constraints:

The number of nodes in the tree will be in the range [0, 104].
-108 <= Node.val <= 108
All the values Node.val are unique.
-108 <= val <= 108
It's guaranteed that val does not exist in the original BST.



I solved this task by myself!

Runtime 120 ms Beats 25.94% of users with C#
Memory 54.79 MB Beats 32.71% of users with C#

 */
internal class m_701_InsertIntoABinarySearchTree
{
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root == null)
        {
            return new TreeNode { val = val };
        }

        TreeNode first = root;
        FindNodeToInsert(root, val);
        return first;
    }

    private TreeNode FindNodeToInsert(TreeNode root, int value)
    {
        if (root.val < value && root.right != null)
        {
            return FindNodeToInsert (root.right, value);
        }

        if ((root.val > value) && root.left != null)
        {
            return FindNodeToInsert(root.left, value);
        }

        if (root.val < value)
        {
            root.right = new TreeNode { val = value };
            return root;
        }
        else 
        {
            root.left = new TreeNode { val = value };
            return root;
        }        
    }
}

public class m_701_InsertIntoABinarySearchTree_BootStrapper
{
    public void Run()
    {
        TreeNode tree_1 = new TreeNode { val = 1 };
        TreeNode tree_3 = new TreeNode { val = 3 };
        TreeNode tree_2 = new TreeNode { val = 2, left = tree_1, right = tree_3 };

        TreeNode tree_7 = new TreeNode { val = 7 };
        TreeNode tree_4 = new TreeNode { val = 4, left = tree_2, right = tree_7 };

        TreeNode treeNode = new m_701_InsertIntoABinarySearchTree().InsertIntoBST(tree_4, 5);
    }
}