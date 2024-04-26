namespace ByArea.BST.Minimum_Absolute_Difference_in_BST_530_e;

/*
 Given the root of a Binary Search Tree (BST), return the minimum absolute difference between 
the values of any two different nodes in the tree.

Example 1:

Input: root = [4,2,6,1,3]
Output: 1

                4
               / \
              2   6
             /\
            1  3

Example 2:

Input: root = [1,0,48,null,null,12,49]

                1
               / \
              0   48
                  / \
                 12  49  

Output: 1

Note: This question is the same as 783: https://leetcode.com/problems/minimum-distance-between-bst-nodes/
 */


/*
Runtime 88 ms Beats 26.50% of users with C#

Memory 44.97MB Beats 83.33%of users with C#
 */
internal class Minimum_Absolute_Difference_in_BST_530_e
{
    private int _result = int.MaxValue;
    private int? _previous = null;

    public int GetMinimumDifference(TreeNode root)
    {
        if (root.left != null)
        {
            GetMinimumDifference(root.left);
        }

        if (_previous != null)
        {
            _result = Math.Min(_result, root.val - _previous.Value);
        }

        _previous = root.val;

        if (root.right != null)
        {
            GetMinimumDifference(root.right);
        }

        return _result;
    }
}
