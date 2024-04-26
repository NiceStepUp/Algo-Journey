namespace ByArea.BST.MinimumDistanceBetweenBSTNodes_783_e;

/*
https://leetcode.com/problems/minimum-distance-between-bst-nodes/description/
Given the root of a Binary Search Tree (BST), return the minimum difference between 
the values of any two different nodes in the tree. 

Example 1:
Input: root = [4,2,6,1,3]
Output: 1


Example 2:
Input: root = [1,0,48,null,null,12,49]
Output: 1
 

Constraints:
The number of nodes in the tree is in the range [2, 100].
0 <= Node.val <= 10 degree 5
 */

// The following solution is upvoted by 225 people
internal class MinimumDistanceBetweenBSTNodes_783_e
{
    private int _result = int.MaxValue;
    private int? _prev = null;

    public int MinDiffInBST(TreeNode root)
    {
        if (root.left != null)
        {
            MinDiffInBST(root.left);
        }

        if (_prev != null)
        {
            _result = Math.Min(_result, root.val - _prev.Value);
        }

        _prev = root.val;


        if (root.right != null)
        {
            MinDiffInBST(root.right);
        }

        return _result;
    }

}


// Iterative solution
internal class MinimumDistanceBetweenBSTNodes_783_e_IterativeSolution
{
    public int MinDiffInBST(TreeNode root)
    {
        int difference = int.MaxValue;
        
        if (root == null)
        {
            return difference;
        }

        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode previous = null;

        while (stack.Count > 0 || root != null) 
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }

            TreeNode popped = stack.Pop();
            if (previous != null)
            {
                difference = Math.Min(difference, popped.val - previous.val);
            }

            previous = popped;
            root = popped.right;
        }

        return difference;
    }

}

public class BootStrapper_MinimumDistanceBetweenBSTNodes_783_e
{
    public void Run()
    {
        TreeNode tree_1 = new TreeNode() { val = 1 };
        TreeNode tree_3 = new TreeNode() { val = 3 };
        TreeNode tree_2 = new TreeNode() { val = 2, left = tree_1, right = tree_3 };
                
        TreeNode tree_6 = new TreeNode() { val = 6 };
        TreeNode tree_4 = new TreeNode()
        {
            val = 4,
            left = tree_2,
            right = tree_6
        };

        new MinimumDistanceBetweenBSTNodes_783_e().MinDiffInBST(tree_4);
    }
}

